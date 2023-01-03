
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Domain.Entities;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;
using Response = PartnerPortal.Domain.Entities.Response;
using PartnerPortal.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Infrastructure.Persistence;
using PartnerPortal.Application.Common.Interfaces;
using AutoMapper;
using Duende.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PartnerPortal.Application.TodoItems.Commands;


namespace PartnerPortal.WebApi.Controllers
{

	public class RegistrationController : ApiControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		//private readonly IEmailService _emailService;
		private readonly IConfiguration _configuration;


		private readonly IMapper _mapper;
		public RegistrationController(UserManager<ApplicationUser> userManager,
		RoleManager<IdentityRole> roleManager, IMapper mapper,
		SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			//_emailService = emailService;
			_configuration = configuration;
		}


		[HttpPost]
		public async Task<IActionResult> Register([FromBody] Users registerUser, string role)
		{
			//Check User Exist
			var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
			if (userExist != null)
			{
				return StatusCode(StatusCodes.Status403Forbidden,
				new Response { Status = "Error", Message = "User already exists!" });
			}

			//Add the User in the database
			ApplicationUser user = new()
			{
				Email = registerUser.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = registerUser.Username,
				PhoneNumber = registerUser.PhoneNumber,
				TwoFactorEnabled = true
			};
			if (await _roleManager.RoleExistsAsync(role))
			{
				var result = await _userManager.CreateAsync(user);
				if (!result.Succeeded)
				{
					return StatusCode(StatusCodes.Status500InternalServerError,
					new Response { Status = "Error", Message = "User Failed to Create" });
				}
				//Add role to the user....

				await _userManager.AddToRoleAsync(user, role);

				////Add Token to Verify the email....
				//var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);




				return StatusCode(StatusCodes.Status200OK,
				new Response { Status = "Success", Message = $"User created {user.Email} SuccessFully" });

			}
			else
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
				new Response { Status = "Error", Message = "This Role Doesnot Exist." });
			}


		}

	}
}

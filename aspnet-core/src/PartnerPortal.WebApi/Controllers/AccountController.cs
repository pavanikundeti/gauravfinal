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
using PartnerPortal.Domain.Entities.DataTransferObjects;
using Microsoft.AspNetCore.WebUtilities;
using PartnerPortal.WebApi.Services;
using PartnerPortal.WebApi.Settings;
using SendGrid.Helpers.Mail;
using Microsoft.IdentityModel.Tokens;

namespace PartnerPortal.WebApi.Controllers
{
	
	public class AccountController : ApiControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		//private readonly IEmailService _emailService;
		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		private readonly Services.IMailService _mailService;
		private readonly Settings.MailSettings _mailSettings;
		private readonly MailRequest _mailRequest;
		private readonly ApplicationDbContext _dbContext;

		public AccountController(UserManager<ApplicationUser> userManager,
		RoleManager<IdentityRole> roleManager, IMapper mapper,
		SignInManager<ApplicationUser> signInManager, IConfiguration configuration, Services.IMailService mailService, MailRequest mailRequest, ApplicationDbContext dbContext)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_mailService = mailService;
			_configuration = configuration;
			_mailRequest = mailRequest;
			_dbContext = dbContext;
		}

		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
		{
			if (loginModel.Username.IsNullOrEmpty() || loginModel.Password.IsNullOrEmpty())
			{
				return ValidationProblem("Email or Password is null");
			}

			var user = await _userManager.FindByEmailAsync(loginModel.Username);
			if (user == null)
			{
				return NotFound("Invalid email and/or password");
			}

			var passwordSignInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, isPersistent: true, lockoutOnFailure: false);
			if (!passwordSignInResult.Succeeded)
			{
				return NotFound("Invalid email and/or password");
            }

			return Ok("User logged in " + loginModel.Username);

		}

        

		[HttpPost]
		[Route("googleLogin")]
		public async Task<IActionResult> GoogleLogin([FromBody] string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if(user == null)
			{
				return StatusCode(StatusCodes.Status404NotFound,
					new Response { Status = "Not found", Message = "User not found" });
			}
			else if (user.TwoFactorEnabled)
			{
				await _signInManager.SignOutAsync();
				return StatusCode(StatusCodes.Status200OK,
					new Response { Status = "Success", Message = $"user loggd in. Welcome {user.Email}" });
			}
			return Unauthorized();
		}

		[HttpPost("ForgotPassword")]
		public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
			if (user == null)
			{
				return BadRequest("Invalid Request");
			}

			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			var param = new Dictionary<string, string?> {
				{ "token", token},
				{ "email", forgotPasswordDto.Email}
			};

			var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);

			var emailBody = _dbContext.EmailTemplates.FirstOrDefault(x => x.TemplateCode == 3.ToString());
			var emailBody1 = emailBody.MessageTemplate.Replace("{NAME}", user.Email).Replace("{link}", callback);


			_mailRequest.ToEmail = user.Email;
			_mailRequest.Subject = "Reset password";
			_mailRequest.Body = emailBody1;
			_mailRequest.Attachments = null;

			var message = _mailRequest;

            await _mailService.SendEmailAsync(message);

            return Ok();
		}

		[HttpPost("ResetPassword")]
		public async Task<IActionResult> ResetPassword([FromBody]ResetPasswordDto resetPasswordDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
			if (user == null)
				return BadRequest("Invalid Request");

			var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);

			if (!resetPassResult.Succeeded)
			{
				var errors = resetPassResult.Errors.Select(e => e.Description);

				return BadRequest(new { Errors = errors });
			}

			return Ok();
		}
	}
}
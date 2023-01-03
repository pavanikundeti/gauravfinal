
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Models;
using PartnerPortal.Application.TodoItems.Queries;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Identity;
using PartnerPortal.Infrastructure.Persistence;
using System.Data;
//using PartnerPortal.Domain.Entities.RegisterUser;



namespace PartnerPortal.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly ApplicationDbContext _DbContext;

		public string Id { get; private set; }

		public UsersController(ApplicationDbContext DbContext)
		{
			_DbContext = DbContext;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<IdentityUser>>> GetRoles()
		{
			if (_DbContext.Users == null)
			{
				return NotFound();
			}
			return await _DbContext.Users.ToListAsync();
		}
		[HttpGet("{id}")]

		public async Task<ActionResult<IdentityUser>> GetRole(string id)
		{
			if (_DbContext.Users == null)
			{
				return NotFound();
			}
			var user = await _DbContext.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			return user;
		}
		//[HttpPut("{id}")]
		//public async Task<ActionResult<IdentityUser>>PutUsers(string id, Users	users)
		//{
		//	//if (id != Id)
		//	//{
		//	//	return BadRequest();
		//	//}
		//	_DbContext.Entry(users).State = EntityState.Modified;
		//	try
		//	{
		//		await _DbContext.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!UserExits(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}
		//	return NoContent();
		//}
		//private bool UserExits(string id)
		//{
		//	return (_DbContext.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		//}
		//[HttpPut("{id}")] 
		//public async Task<IActionResult> PutUser(string id, Reg_user user) 
		//{ 
		//	//if (id != Id) 
		//	//{ 
		//	//	return BadRequest(); 
		//	//} 
		//	_DbContext.Entry(user).State = EntityState.Modified;
		//	try 
		//	{
		//		await _DbContext.SaveChangesAsync();
		//	} 
		//	catch (DbUpdateConcurrencyException) 
		//	{ 
		//		if (!UserExits(id))
		//		{ 
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;

		//		}
		//	} 
		//		return NoContent(); 
		//}
		//private bool UserExits(string id)
		//{
		//	return (_DbContext.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		//}
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutRole(string id, Users role)
		//{

		//	_DbContext.Entry(role).State = EntityState.Modified;

		//	try
		//	{
		//		await _DbContext.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!UsersExits(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}
		//	return NoContent();
		//}
		//private bool UsersExits(string id)
		//{
		//	return (_DbContext.Users?.Any(e => e.Id == id)).GetValueOrDefault();

		//}
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutUsers(string id, Users users)
		//{
		//	if (id != users.Id)
		//	{
		//		return BadRequest();
		//	}
		//	_DbContext.Entry(users).State = EntityState.Modified;

		//	try
		//	{
		//		await _DbContext.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!UserExits(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}
		//	return NoContent();
		//}
		//private bool UserExits(string id)
		//{
		//	return (_DbContext.Users?.Any(e => e.Id == id)).GetValueOrDefault();
		//}
		[HttpPut]

		[Route("{id}")]

		public async Task<IActionResult> UpdateEmployee([FromRoute] string id, Users updateEmployeeRequest)

		{

			var employee = await _DbContext.Users.FindAsync(id);

			if (employee == null)

			{

				return NotFound();

			}

			employee.UserName = updateEmployeeRequest.Username;

			employee.Email = updateEmployeeRequest.Email;

			employee.PhoneNumber = updateEmployeeRequest.PhoneNumber;

			await _DbContext.SaveChangesAsync();

			return Ok(employee);

		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<IdentityUser>> DeleteUser(string id)
		{
			if (_DbContext.Users == null)
			{
				return NotFound();
			}
			var User = await _DbContext.Users.FindAsync(id);
			if (User == null)
			{
				return NotFound();
			}
			_DbContext.Users.Remove(User);
			await _DbContext.SaveChangesAsync();
			return NoContent();
		}
		//[HttpPut]

		//[Route("{id}")]

		//public async Task<IActionResult> UpdateEmployee([FromRoute] string id, Users updateEmployeeRequest)

		//{
		//	var Users = await _DbContext.Users.FindAsync(id);


		//	if (Users == null)

		//	{

		//		return NotFound();

		//	}
		//	//var DbContext Users = await _DbContext.Users.FindAsync(id);
		//	_DbContext.Users.Remove(Users);
		//	await _DbContext.SaveChangesAsync();

		//	return Ok(Users);

		//}


	}
}

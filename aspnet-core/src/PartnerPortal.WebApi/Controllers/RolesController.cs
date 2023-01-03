using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Models;
using PartnerPortal.Application.TodoItems.Queries;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;
using System;
using System.Data;

namespace PartnerPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly ApplicationDbContext _DbContext;



        public RolesController(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        [HttpGet]

        public async Task<ActionResult<IEnumerable<IdentityRole>>> GetRoles()
        {
            if (_DbContext.Roles == null)
            {
                return NotFound();
            }
            var roles= await _DbContext.Roles.ToListAsync();
            var rDs = await _DbContext.RoleDescriptions.ToListAsync();
            for(int i = 0; i < roles.Count; i++)
            {
                for(int j = 0; j < rDs.Count; j++)
                {
                    if (roles[i].Id == rDs[j].RoleId)
                    {
                        roles[i].NormalizedName = rDs[j].RolesDescription;
                        break;
                    }
                }
            }
            return await _DbContext.Roles.ToListAsync();
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<IdentityRole>> GetRole(string id)
        {
            if (_DbContext.Roles == null)
            {
                return NotFound();
            }
            var role = await _DbContext.Roles.FindAsync(id);
            var rD = await _DbContext.RoleDescriptions.Where(x => x.RoleId == id).FirstOrDefaultAsync();
            if (role == null)
            {
                return NotFound();
            }
            role.NormalizedName = rD.RolesDescription;
            return role;
        }
        [HttpPost]

        public async Task<IActionResult> PostRole(IdentityRole role)
        {
            RoleDescription rD = new RoleDescription
            {
                RoleId = role.Id,
                RolesDescription = role.NormalizedName
            };
            role.NormalizedName= role.Name.ToUpper();
            _DbContext.Roles.Add(role);
            _DbContext.RoleDescriptions.Add(rD);
            await _DbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = role.Id }, role);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(string id, IdentityRole role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }
            var rD = await _DbContext.RoleDescriptions.Where(x => x.RoleId == id).FirstOrDefaultAsync();
            rD.RolesDescription = role.NormalizedName;
            role.NormalizedName = role.Name.ToUpper();
            _DbContext.Entry(role).State = EntityState.Modified;
            _DbContext.Entry(rD).State = EntityState.Modified;
            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExits(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        private bool RoleExits(string id)
        {
            return (_DbContext.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        [HttpDelete("{id}")]

        public async Task<ActionResult<IdentityRole>> DeleteRole(string id)
        {
            if (_DbContext.Roles == null)
            {
                return NotFound();
            }
            var role = await _DbContext.Roles.FindAsync(id);
            var rD = await _DbContext.RoleDescriptions.Where(x => x.RoleId == id).FirstOrDefaultAsync();
            if (role == null)
            {
                return NotFound();
            }
            _DbContext.Roles.Remove(role);
            _DbContext.RoleDescriptions.Remove(rD);
            await _DbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

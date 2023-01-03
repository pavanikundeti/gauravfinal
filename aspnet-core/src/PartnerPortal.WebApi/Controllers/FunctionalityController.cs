using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Models;
using PartnerPortal.Application.TodoItems.Queries;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;
using System.Data;
namespace PartnerPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionalityController : ControllerBase
    {
        private readonly ApplicationDbContext _DbContext;



        public FunctionalityController(ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Functionality>>> GetFunctionality()
        {
            if (_DbContext.Functionalities == null)
            {
                return NotFound();
            }
            return await _DbContext.Functionalities.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Functionality>> GetFunctionalities(Guid id)
        {
            if (_DbContext.Functionalities == null)
            {
                return NotFound();
            }
            var func = await _DbContext.Functionalities.FindAsync(id);
            if (func == null)
            {
                return NotFound();
            }
            return func;
        }

        [HttpPost]

        public async Task<ActionResult<Functionality>> PostFinctionality(Functionality func)
        {
            _DbContext.Functionalities.Add(func);
            await _DbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFunctionalities), new { id = func.FId }, func);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunctionality(Guid id, Functionality func)
        {
            if (id != func.FId)
            {
                return BadRequest();
            }
            _DbContext.Entry(func).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FunctionalitiesExits(id))
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
        private bool FunctionalitiesExits(Guid id)
        {
            return (_DbContext.Functionalities?.Any(e => e.FId == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Functionality>> DeleteFunctionality(Guid id)
        {
            if (_DbContext.Functionalities == null)
            {
                return NotFound();
            }
            var func = await _DbContext.Functionalities.FindAsync(id);
            if (func == null)
            {
                return NotFound();
            }
            _DbContext.Functionalities.Remove(func);
            await _DbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

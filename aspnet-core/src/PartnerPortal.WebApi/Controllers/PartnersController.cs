using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Partners.Commands;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class PartnersController : ApiControllerBase
    {
        private readonly ApplicationDbContext _fullStackDbContext;

        public PartnersController(ApplicationDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllPartners()
        {
            var partners = await _fullStackDbContext.Partners.ToListAsync();
            return Ok(partners);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult> GetPartnerDetails([FromRoute]Guid id)
        {
           var partner= await _fullStackDbContext.Partners.FirstOrDefaultAsync(x => x.PartnerID == id);
            if(partner == null)
            {
                return NotFound();
            }
            return Ok(partner);
        }
        //[HttpGet]
        //public async Task<ActionResult<PaginatedList<PartnerBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetPartnersWithPaginationQuery query)
        //{
        //    return await Mediator.Send(query);
        //}
        //[HttpGet("{id:Guid}")]
        //public async Task<IActionResult> GetOnePartner(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var details = await _fullStackDbContext.Partners


        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(m => m.PartnerID == id);

        //    if (details == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(details);
        //}
        //[HttpPost("AddSPOC")]
        //public async Task<IActionResult> AddSpoc([FromBody] PartnerSPOC partnerRequest)
        //{
            
        //    await _fullStackDbContext.AspNe
        //    await _fullStackDbContext.SaveChangesAsync();
        //    return Ok(partnerRequest);

        //}

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreatePartnerCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePartner([FromRoute] Guid id)
        {
            var partner = await _fullStackDbContext.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            _fullStackDbContext.Partners.Remove(partner);
            await _fullStackDbContext.SaveChangesAsync();
            return Ok(partner);
        }
    }
}

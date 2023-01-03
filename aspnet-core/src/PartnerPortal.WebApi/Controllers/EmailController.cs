using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Data;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ApplicationDbContext _apiDbContext;
        public EmailController(ApplicationDbContext apiDbContext)
        {
            _apiDbContext = apiDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTemplates()
        {
            var template = await _apiDbContext.EmailTemplates.ToListAsync();
            return Ok(template);
        }




        [HttpPost]
        public async Task<IActionResult> AddTemplate([FromBody] EmailTemplate emailTemplates)
        {
            emailTemplates.EmailTemplateID = Guid.NewGuid();
            await _apiDbContext.EmailTemplates.AddAsync(emailTemplates);
            await _apiDbContext.SaveChangesAsync();



            return Ok(emailTemplates);



        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetTemplate([FromRoute] Guid id)
        {
            var template =
            await _apiDbContext.EmailTemplates.FirstOrDefaultAsync(x => x.EmailTemplateID == id);
            if (template == null)
            {
                return NotFound();



            }
            return Ok(template);




        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateBench([FromRoute] Guid id, EmailTemplate updatetemplate)
        {
            var template = await _apiDbContext.EmailTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }
            template.TemplateName = updatetemplate.TemplateName;
            template.TemplateCode = updatetemplate.TemplateCode;
            template.MessageTemplate = updatetemplate.MessageTemplate;
            await _apiDbContext.SaveChangesAsync();
            return Ok(template);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteTemplate([FromRoute] Guid id)
        {
            var template = await _apiDbContext.EmailTemplates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }
            _apiDbContext.EmailTemplates.Remove(template);
            await _apiDbContext.SaveChangesAsync();
            return Ok(template);
        }



    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.ProjectManagers.Commands;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    
    public class ProjectManagerController : ApiControllerBase
    {
        private readonly ApplicationDbContext _fullStackDbContext;



        public ProjectManagerController(ApplicationDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployees()
        {
            var projectmanagers = await _fullStackDbContext.ProjectManagers.ToListAsync();
            return Ok(projectmanagers);
        }
        /*[HttpGet]
        public async Task<ActionResult<PaginatedList<ProjectManagerBriefDto>>> GetProjectManagersWithPagination([FromQuery] GetProjectManagersWithPaginationQuery query)
        {
            return await Mediator.Send(query);
        }*/
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateProjectManagerCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpGet]
        [Route("{projectManagerID:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid projectManagerID)
        {
            var employee = await _fullStackDbContext.ProjectManagers.FirstOrDefaultAsync(x => x.ProjectManagerID == projectManagerID);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);



        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateProjectManagerCommand command)
        {
            if (id != command.ProjectManagerID)
            {
                return BadRequest();
            }



            await Mediator.Send(command);



            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteProjectManagerCommand(id));



            return NoContent();
        }

        

    }
}

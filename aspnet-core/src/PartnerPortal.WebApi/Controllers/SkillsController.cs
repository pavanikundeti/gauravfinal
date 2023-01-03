using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.TodoLists.Commands;
using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using PartnerPortal.Application.TodoLists.Queries.GetTodos;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    public class SkillsController : ApiControllerBase
    {
        private readonly ApplicationDbContext _fullStackDbContext;

        public SkillsController(ApplicationDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<SkillsVm>> Get()
        {
            return await Mediator.Send(new GetSkillsQuery());
        }
        public async Task<ActionResult<int>> Create(CreateSkillsCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("Skills")]
        public Skill[] Getskill()
        {
            var listofCountry = _fullStackDbContext.Skills.ToList();
            return listofCountry.ToArray();




        }

    }
}

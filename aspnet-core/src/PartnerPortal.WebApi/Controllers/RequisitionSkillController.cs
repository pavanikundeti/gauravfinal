using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.Dummy.Commands;
using PartnerPortal.Application.Requisitions.Commands;

namespace PartnerPortal.WebApi.Controllers
{
    public class RequisitionSkillController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequisitionSkillCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}

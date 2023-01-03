using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.Dummy.Commands;

using PartnerPortal.Application.Dummy.Commands.PartnerPortal.Application.Requisitions.Commands;

namespace PartnerPortal.WebApi.Controllers
{
    public class RequisitionPartnerController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequisitionPartnerCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}

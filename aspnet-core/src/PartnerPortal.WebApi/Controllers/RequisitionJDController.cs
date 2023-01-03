using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.Dummy.Commands;
using PartnerPortal.Application.Requisitions.Commands;

namespace PartnerPortal.WebApi.Controllers
{
    public class RequisitionJDController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRequisitionJDCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}

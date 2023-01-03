using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Requisitions.Get_Requisition;
using PartnerPortal.Application.Requisitions.Commands;
using PartnerPortal.Application.TodoItems.Commands;
using PartnerPortal.Application.TodoLists.Commands;
using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using PartnerPortal.Application.TodoLists.Queries.GetTodos;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;
using System.Collections.Immutable;

namespace PartnerPortal.WebApi.Controllers
{
    
    public class RequisitionController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<RequisitionVm>> Get()
        {
            return await Mediator.Send(new GetRequisitionQuery());
        }


        

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetRequisitionQuery { RequisitionID = id });
            return Ok(vm);
        }



        public async Task<ActionResult<int>> Create(CreateRequisitionCommand command)
        {
            return await Mediator.Send(command);
        }

        //[HttpPut("{id:guid}")]
        //public async Task<ActionResult> Update(Guid id, UpdateRequisitionCommand command)
        //{
        //    if (id != command.RequisitionID)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateItemDetails(Guid id, UpdateRequisitionDetailCommand command)
        //{
        //    if (id != command.RequisitionID)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteRequisitionCommand(id));

            return NoContent();
        }
    }
}

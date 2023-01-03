using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Commands
{
    public record UpdateRequisitionDetailCommand : IRequest
    {
        public Guid RequisitionID { get; set; }
        public string RequisitionCode { get; set; }
        public string PotentialNumber { get; set; }
        public string Complexity { get; set; }
        public DateTime RequisitionDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public String ClientName { get; set; }
        public Guid ClientCountreyID { get; set; }
        public String ProjectType { get; set; }
        public Guid SalesPersonUserID { get; set; }
        public Guid ProjectManagerID { get; set; }
        public Byte RequisitionStatus { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public Double EstimatedBudget { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid CurrencyID { get; set; }
        public string? ProjectDescription { get; set; }

    }

    public class UpdateRequisitionDetailCommandHandler : IRequestHandler<UpdateRequisitionDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRequisitionDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequisitionDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.requisitions
                .FindAsync(new object[] { request.RequisitionID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Requisition), request.RequisitionID);
            }

            entity.RequisitionCode = request.RequisitionCode;
            entity.PotentialNumber = request.PotentialNumber;
            entity.Complexity = request.Complexity;
            entity.RequisitionDate = request.RequisitionDate;
            entity.DeadlineDate = request.DeadlineDate;
            entity.ClientName = request.ClientName;
            entity.ClientCountreyID = request.ClientCountreyID;
            entity.ProjectType = request.ProjectType;
            entity.SalesPersonUserID = request.SalesPersonUserID;
            entity.ProjectManagerID = request.ProjectManagerID;
            entity.RequisitionStatus = request.RequisitionStatus;
            entity.ExpectedStartDate = request.ExpectedStartDate;
            entity.EstimatedBudget = request.EstimatedBudget;
            entity.DepartmentID = request.DepartmentID;
            entity.CurrencyID = request.CurrencyID;
            entity.ProjectDescription = request.ProjectDescription;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

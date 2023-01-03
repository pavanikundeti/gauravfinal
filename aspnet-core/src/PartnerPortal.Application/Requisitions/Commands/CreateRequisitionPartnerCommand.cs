using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Dummy.Commands
{
    namespace PartnerPortal.Application.Requisitions.Commands
    {
        public record CreateRequisitionPartnerCommand : IRequest<int>
        {
            public Guid RequsitionPartnerID { get; set; }
            public Guid RequestionID { get; set; }
            public Guid PartnerId { get; set; }
        }

        public class CreateRequisitionPartnerCommandHandler : IRequestHandler<CreateRequisitionPartnerCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateRequisitionPartnerCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateRequisitionPartnerCommand request, CancellationToken cancellationToken)
            {
                var entity = new RequisitionPartner
                {
                    //SalesPersonId = request.((SalesPersonId).ToString()),
                    RequestionID = request.RequestionID,
                    PartnerId = request.PartnerId,
                };

                //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

                _context.RequisitionPartners.Add(entity);

                await _context.SaveChangesAsync(cancellationToken);

                //return request.DepartmentID;
                return 1;

            }
        }
    }
}

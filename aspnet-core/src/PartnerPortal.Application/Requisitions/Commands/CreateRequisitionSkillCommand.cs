using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.Dummy.Commands;
using PartnerPortal.Application.Requisitions.Commands;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Commands
{
    public record CreateRequisitionSkillCommand : IRequest<int>
    {
        public Guid RequisitionSkillID { get; set; }
        public Guid RequisitionID { get; set; }
        public Guid SkillID { get; set; }
        public Byte Mandatory { get; set; }
        public int Experience { get; set; }
        public string Comments { get; set; }
    }


    public class CreateRequisitionSkillCommandHandler : IRequestHandler<CreateRequisitionSkillCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRequisitionSkillCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRequisitionSkillCommand request, CancellationToken cancellationToken)
        {
            var entity = new RequisitionSkill
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                RequisitionID = request.RequisitionID,
                SkillID = request.SkillID,
                Mandatory = request.Mandatory,
                Experience = request.Experience,
                Comments = request.Comments,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.RequisitionSkills.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}


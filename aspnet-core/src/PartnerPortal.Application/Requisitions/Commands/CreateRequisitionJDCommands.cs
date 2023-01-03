using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Commands
{
    public record CreateRequisitionJDCommand : IRequest<int>
    {
        public Guid RequisitionJDID { get; set; }
        public Guid RequisitionID { get; set; }
        public string JobDescription { get; set; }
        public int Duration { get; set; }
        public string DurationUnits { get; set; }
        public string ShiftTimings { get; set; }
        public int NoOfResources { get; set; }
        public int OpenPositions { get; set; }
        public String KeyDescription { get; set; }
        public string PreferredEducation { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }
        public string JDFileName { get; set; }
    }

    public class CreateRequisitionJDCommandHandler : IRequestHandler<CreateRequisitionJDCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRequisitionJDCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRequisitionJDCommand request, CancellationToken cancellationToken)
        {
            var entity = new RequisitionJD
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                RequisitionID = request.RequisitionID,
                JobDescription = request.JobDescription,
                Duration = request.Duration,
                DurationUnits = request.DurationUnits,
                ShiftTimings = request.ShiftTimings,
                NoOfResources = request.NoOfResources,
                OpenPositions = request.OpenPositions,
                KeyDescription = request.KeyDescription,
                PreferredEducation = request.PreferredEducation,
                MinExperience = request.MinExperience,
                MaxExperience = request.MaxExperience,
                JDFileName = request.JDFileName,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.RequisitionJDs.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}

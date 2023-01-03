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
    public record CreateRequisitionCommand : IRequest<int>
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
        public Guid SkillID { get; set; }
        public Byte Mandatory { get; set; }
        public int Experience { get; set; }
        public string Comments { get; set; }
        public Guid PartnerId { get; set; }
    }

    public class CreateRequisitionCommandHandler : IRequestHandler<CreateRequisitionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRequisitionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRequisitionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Requisition
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                RequisitionCode = request.RequisitionCode,
                PotentialNumber = request.PotentialNumber,
                Complexity = request.Complexity,
                RequisitionDate = request.RequisitionDate,
                DeadlineDate = request.DeadlineDate,
                ClientName = request.ClientName,
                ClientCountreyID = request.ClientCountreyID,
                ProjectType = request.ProjectType,
                SalesPersonUserID= request.SalesPersonUserID,
                ProjectManagerID= request.ProjectManagerID,
                RequisitionStatus=  request.RequisitionStatus,
                ExpectedStartDate = request.ExpectedStartDate,
                EstimatedBudget = request.EstimatedBudget,
                DepartmentID = request.DepartmentID,
                CurrencyID = request.CurrencyID,
                ProjectDescription = request.ProjectDescription,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.requisitions.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            var getreqID = entity.RequisitionID;
            var entity2 = new RequisitionJD
            {
                RequisitionID = getreqID,
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

            _context.RequisitionJDs.Add(entity2);
            await _context.SaveChangesAsync(cancellationToken);

            var entity3 = new RequisitionSkill
            {
                RequisitionID = getreqID,
                SkillID= request.SkillID,
                Mandatory= request.Mandatory,
                Experience= request.Experience,
                Comments= request.Comments,

            };

            _context.RequisitionSkills.Add(entity3);
            await _context.SaveChangesAsync(cancellationToken);


            var entity4 = new RequisitionPartner
            {
                RequestionID = getreqID,
                PartnerId=request.PartnerId,
            };

            _context.RequisitionPartners.Add(entity4);
            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}

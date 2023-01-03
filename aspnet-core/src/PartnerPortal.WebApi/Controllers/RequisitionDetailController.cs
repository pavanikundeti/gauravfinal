using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.Requisitions.Get_Requisition;
using PartnerPortal.Application.TodoLists.Queries.GetTodos;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{

    public class RequisitionDetailController : ApiControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public RequisitionDetailController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("getRequisitions")]
        public IEnumerable<RequisitionDetailDto> getRequisitions()
        {
            var reqList = (from requis in dbContext.requisitions
                           join reqskill in dbContext.RequisitionSkills on requis.RequisitionID equals reqskill.RequisitionID
                           join reqjd in dbContext.RequisitionJDs on requis.RequisitionID equals reqjd.RequisitionID
                           //join reqfile in dbContext.RequisitionFiles on requis.RequisitionID equals reqfile.RequisitionID
                           join reqpart in dbContext.RequisitionPartners on requis.RequisitionID equals reqpart.RequestionID
                           select new RequisitionDetailDto()
                           {
                               RequisitionID = requis.RequisitionID,
                               RequisitionCode = requis.RequisitionCode,
                               PotentialNumber = requis.PotentialNumber,
                               Complexity = requis.Complexity,
                               RequisitionDate = requis.RequisitionDate,
                               DeadlineDate = requis.DeadlineDate,
                               ExpectedStartDate = requis.ExpectedStartDate,
                               ClientName = requis.ClientName,
                               ProjectType = requis.ProjectType,
                               RequisitionStatus = requis.RequisitionStatus,
                               EstimatedBudget = requis.EstimatedBudget,
                               DepartmentID = requis.DepartmentID,
                               CurrencyID = requis.CurrencyID,
                               ProjectDescription = requis.ProjectDescription,
                               JobDescription = reqjd.JobDescription,
                               Duration = reqjd.Duration,
                               DurationUnits = reqjd.DurationUnits,
                               ShiftTimings = reqjd.ShiftTimings,
                               NoOfResources = reqjd.NoOfResources,
                               OpenPositions = reqjd.OpenPositions,
                               KeyDescription = reqjd.KeyDescription,
                               PreferredEducation = reqjd.PreferredEducation,
                               MinExperience = reqjd.MaxExperience,
                               MaxExperience = reqjd.MaxExperience,
                               JDFileName = reqjd.JDFileName,
                               //FileName= reqfile.FileName,
                               SkillID= reqskill.SkillID,
                               Mandatory= reqskill.Mandatory,
                               Experience= reqskill.Experience,
                               Comments= reqskill.Comments,
                               PartnerId=reqpart.PartnerId,

                           }).ToList();
            return reqList;
        }



        [HttpGet("{id}")]
        public IEnumerable<RequisitionDetailDto> getRequisitionsByID(Guid id )
        {
            var reqList = (from requis in dbContext.requisitions
                           join reqskill in dbContext.RequisitionSkills on requis.RequisitionID equals reqskill.RequisitionID
                           join reqjd in dbContext.RequisitionJDs on requis.RequisitionID equals reqjd.RequisitionID where id.Equals( requis.RequisitionID )
                           //join reqfile in dbContext.RequisitionFiles on requis.RequisitionID equals reqfile.RequisitionID
                           join reqpart in dbContext.RequisitionPartners on requis.RequisitionID equals reqpart.RequestionID
                           select new RequisitionDetailDto()
                           {
                               RequisitionID = requis.RequisitionID,
                               RequisitionCode = requis.RequisitionCode,
                               PotentialNumber = requis.PotentialNumber,
                               Complexity = requis.Complexity,
                               RequisitionDate = requis.RequisitionDate,
                               DeadlineDate = requis.DeadlineDate,
                               ExpectedStartDate = requis.ExpectedStartDate,
                               ClientName = requis.ClientName,
                               ProjectType = requis.ProjectType,
                               RequisitionStatus = requis.RequisitionStatus,
                               EstimatedBudget = requis.EstimatedBudget,
                               DepartmentID = requis.DepartmentID,
                               CurrencyID = requis.CurrencyID,
                               ProjectDescription = requis.ProjectDescription,
                               JobDescription = reqjd.JobDescription,
                               Duration = reqjd.Duration,
                               DurationUnits = reqjd.DurationUnits,
                               ShiftTimings = reqjd.ShiftTimings,
                               NoOfResources = reqjd.NoOfResources,
                               OpenPositions = reqjd.OpenPositions,
                               KeyDescription = reqjd.KeyDescription,
                               PreferredEducation = reqjd.PreferredEducation,
                               MinExperience = reqjd.MaxExperience,
                               MaxExperience = reqjd.MaxExperience,
                               JDFileName = reqjd.JDFileName,
                               SkillID = reqskill.SkillID,
                               Mandatory = reqskill.Mandatory,
                               Experience = reqskill.Experience,
                               Comments = reqskill.Comments,
                               PartnerId = reqpart.PartnerId,
                           }).ToList();
            return reqList;
        }


    }
}

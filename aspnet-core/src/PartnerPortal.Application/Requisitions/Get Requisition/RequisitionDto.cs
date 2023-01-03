using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Get_Requisition
{
    public class RequisitionDto : IMapFrom<Requisition>
    {
        public RequisitionDto()
        {
            RequisitionSkills = new List<RequisitionSkillsDto>();
            RequisitionJds = new List<RequisitionJDsDto>();
            RequisitionFiles = new List<RequisitionFilesDto>();
            RequisitionPartners = new List<RequisitionPartnersDto>();
        }

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

        public IList<RequisitionSkillsDto> RequisitionSkills { get; set; }
        public IList<RequisitionJDsDto> RequisitionJds { get; set; }
        public IList<RequisitionFilesDto> RequisitionFiles { get; set; }
        public IList<RequisitionPartnersDto> RequisitionPartners { get; set; }
    }
}

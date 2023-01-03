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
    public class RequisitionDetailDto: IMapFrom<Requisition>, IMapFrom<RequisitionFile>, IMapFrom<RequisitionJD>, IMapFrom<RequisitionSkill>, IMapFrom<RequisitionPartner>
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
        public Byte RequisitionStatus { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public Double EstimatedBudget { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid CurrencyID { get; set; }
        public string? ProjectDescription { get; set; }
        //JD
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

        //Files
        public string FileName { get; set;}

        //Skills
        public Guid SkillID { get; set; }
        public Byte Mandatory { get; set; }
        public int Experience { get; set; }
        public string Comments { get; set; }

        //partners
        public Guid PartnerId { get; set; }
    }
}

using AutoMapper;
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
    public class RequisitionJDsDto : IMapFrom<RequisitionJD>
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequisitionJD, RequisitionJDsDto>();
            /*.ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority)*/
        }
    }
}

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
    public class RequisitionSkillsDto : IMapFrom<RequisitionSkill>
    {
        public Guid RequisitionSkillID { get; set; }
        public Guid RequisitionID { get; set; }
        public Guid SkillID { get; set; }
        public Byte Mandatory { get; set; }
        public int Experience { get; set; }
        public string Comments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequisitionSkill, RequisitionSkillsDto>();
                /*.ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority)*/
        }
    }
}

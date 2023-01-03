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
    public class RequisitionPartnersDto : IMapFrom<RequisitionPartner>
    {
        public Guid RequsitionPartnerID { get; set; }
        public Guid RequestionID { get; set; }
        public Guid PartnerId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequisitionPartner, RequisitionPartnersDto>();
            /*.ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority)*/
        }
    }
}

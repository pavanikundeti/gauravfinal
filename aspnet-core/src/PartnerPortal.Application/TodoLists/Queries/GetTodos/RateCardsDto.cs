using AutoMapper;
using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.GetTodos
{
    public class RateCardsDto : IMapFrom<RateCard>
    {
        public Guid RateCardId { get; set; }
        public Guid SkilId { get; set; }
        [ForeignKey("SkilId")]
        public Skill Skill { get; set; }
        public byte MinYrExperience { get; set; }



        public byte MaxYrExperience { get; set; }
        public double RatePerHrUSD { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RateCard, RateCardsDto>();
            /*.ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority)*/
        }
    }
   
}

using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.GetTodos
{
    public class SkillsDto : IMapFrom<Skill>
    {
       
        public Guid SkillID { get; set; }
        public string SkillName { get; set; }
       // public IList<RateCard> RateCards { get; private set; } = new List<RateCard>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Skill : BaseAuditableEntity
    {
        [Key]
        public Guid SkillID { get; set; }
        public string SkillName { get; set; }
        public IList<RateCard> RateCards { get; private set; } = new List<RateCard>();
    }
}

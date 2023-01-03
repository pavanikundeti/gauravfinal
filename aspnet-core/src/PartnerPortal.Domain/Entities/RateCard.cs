using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class RateCard : BaseAuditableEntity
    {
        [Key]
        public Guid RateCardId { get; set; }
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }
        public byte MinYrExperience { get; set; }



        public byte MaxYrExperience { get; set; }
        public double RatePerHrUSD { get; set; }
    }
}

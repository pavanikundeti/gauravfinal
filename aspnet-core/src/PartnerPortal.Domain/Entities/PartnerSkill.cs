using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class PartnerSkill
    {
        [Key]
        public Guid PartnerSkillID { get; set; }
        public Guid PartnerID { get; set; }
        [ForeignKey("PartnerID")]
        public virtual Partner Partner { get; set; }
        public Guid? SkillID { get; set; }

    }
}

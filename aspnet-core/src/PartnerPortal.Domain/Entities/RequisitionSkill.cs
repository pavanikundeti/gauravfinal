using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class RequisitionSkill
    {
        [Key]
        public Guid RequisitionSkillID { get; set; }
        public Guid RequisitionID { get; set; }
        [ForeignKey("RequisitionID")]
        public Requisition Requisition { get; set; }
        public Guid SkillID { get; set; }
        [ForeignKey("SkillID")]
        public Skill Skill { get; set; }
        public Byte Mandatory { get; set; } 
        public int Experience { get; set; }
        public string Comments { get; set; }
    }
}

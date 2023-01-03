using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class ProjectManagerSkill
    {
        [Key]
        public Guid ProjectManagerSkillID { get; set; }
        public Guid ProjectManagerID { get; set; }
        [ForeignKey("ProjectManagerID")]
        public virtual ProjectManager ProjectManager { get; set; }
        public Guid? SkillID { get; set; }
    }
}

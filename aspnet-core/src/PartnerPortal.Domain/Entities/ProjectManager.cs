using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class ProjectManager :BaseAuditableEntity
    {
        [Key]
        public Guid ProjectManagerID { get; set; }
        [StringLength(100)]
        public string ProjectManagerName { get; set; }
        [StringLength(10)]
        public string EmployeeID { get; set; }



        public DateTime JoiningDate { get; set; }
        [StringLength(100)]
        public string PMEmailID { get; set; }
        [StringLength(50)]
        public string PMPhoneNumber { get; set; }



        public byte[] PMPhoto { get; set; }
        [MaxLength(4)]
        public Int16 PMStatus { get; set; }



        public Guid? PMUserID { get; set; }



        public virtual ICollection<ProjectManagerSkill> ProjectManagerSkills { get; set; }
    }
}

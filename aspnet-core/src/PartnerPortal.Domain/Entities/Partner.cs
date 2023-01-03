using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Partner:BaseAuditableEntity
    {
        [Key]
        public Guid PartnerID { get; set; }
        [StringLength(100)]
        public string PartnerName { get; set; }
        [StringLength(100)]
        public string Location { get; set; }
        public Guid CountryID { get; set; }
       
        public DateTime RegisteredDate { get; set; }
        public Guid? SPOCUserID { get; set; }
        public string Address1 { get; set; }
        public string BillingAddress1 { get; set; }
        public byte[] PartnerImage { get; set; }
        [MaxLength(4)]
        public int PartnerStatus { get; set; }

        public virtual ICollection<PartnerSkill> PartnerSkills { get; set; }
    }
}

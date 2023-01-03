using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class RequisitionPartner
    {
        [Key]
        public Guid RequsitionPartnerID { get; set; }
        public Guid RequestionID { get; set; }
        [ForeignKey("RequestionID")]
        public Requisition Requisition { get; set; }
        public Guid PartnerId { get; set; }
        [ForeignKey("PartnerId")]
        public Partner Partner { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class RequisitionFile
    {
        [Key]
        public Guid RequisitionFileID { get; set; }
        public Guid RequisitionID { get; set; }
        [ForeignKey("RequisitionID")]
        public Requisition Requisition { get; set; }
        public String FileName { get; set; }
        public String FileTypeDescription { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Sales
    {
        [Key]
        public Guid SalesId { get; set; }
        [StringLength(100)]
        public string SalesName { get; set; }
        [StringLength(100)]
        public string SalesEmailId { get; set; }
        public string SalesPhoneNumber { get; set; }

        public byte[] SalesPhoto { get; set; }
        public string SalesStatus { get; set; }
        public Guid SalesUserId { get; set; }
    }
}

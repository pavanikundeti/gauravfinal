using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Functionality
    {
        [Key]
        public Guid FId { get; set; }
        public string description { get; set; }
    }
}

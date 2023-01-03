using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class RoleDescription
    {
        [Key]
        public Guid RDId { get; set; }
        public string RoleId { get; set; }
        public string RolesDescription { get; set; }
    }
}

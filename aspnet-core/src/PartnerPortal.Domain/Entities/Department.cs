using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Department
    {
        [Key]
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
}

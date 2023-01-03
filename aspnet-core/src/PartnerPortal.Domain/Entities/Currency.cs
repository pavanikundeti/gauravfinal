using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Currency
    {
        [Key]
        public Guid CurrencyID { get; set; }
        public string CurrencyName { get; set; }
    }
}

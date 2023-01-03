using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Partners.Queries
{
    public class PartnerBriefDto:IMapFrom<Partner>
    {
        public Guid PartnerID { get; set; }
        public string PartnerName { get; set;}
        public string Location { get; set;}
        public string Country { get; set;}
        public DateTime RegisteredDate { get; set;}
    }
}

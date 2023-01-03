using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Get_Requisition
{
    public class RequisitionVm
    {
        public IList<RequisitionDto> Lists { get; set; } = new List<RequisitionDto>();
    }
}

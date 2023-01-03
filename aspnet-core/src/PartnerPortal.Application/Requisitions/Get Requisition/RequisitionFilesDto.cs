using AutoMapper;
using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Get_Requisition
{
    public class RequisitionFilesDto : IMapFrom<RequisitionFile>
    {
        public Guid RequisitionFileID { get; set; }
        public Guid RequisitionID { get; set; }
        public String FileName { get; set; }
        public String FileTypeDescription { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RequisitionFile, RequisitionFilesDto>();
            /*.ForMember(d => d.Priority, opt => opt.MapFrom(s => (int)s.Priority)*/
        }
    }
}

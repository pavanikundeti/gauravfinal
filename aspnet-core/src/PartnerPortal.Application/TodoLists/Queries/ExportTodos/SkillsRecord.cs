using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.ExportTodos
{
    public class SkillsRecord : IMapFrom<Skill>
    {
        public Guid SkilId { get; set; }
        public string SkillName { get; set; }
    }
}

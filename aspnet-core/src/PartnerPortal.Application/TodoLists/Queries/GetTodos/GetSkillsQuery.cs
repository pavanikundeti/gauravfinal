using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.GetTodos
{
    public record GetSkillsQuery : IRequest<SkillsVm>;



    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, SkillsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;



        public GetSkillsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<SkillsVm> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
        {
            return new SkillsVm
            {
                //PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                //    .Cast<PriorityLevel>()
                //    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                //    .ToList(),



                Lists = await _context.Skills
                    .AsNoTracking()
                    .ProjectTo<SkillsDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.SkillName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}

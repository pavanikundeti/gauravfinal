using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Application.Common.Models;
using PartnerPortal.Application.TodoItems.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Partners.Queries
{
    public record GetPartnersWithPaginationQuery : IRequest<PaginatedList<PartnerBriefDto>>
    {
        public Guid PartnerID { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }
    public class GetPartnersWithPaginationQueryHandler : IRequestHandler<GetPartnersWithPaginationQuery, PaginatedList<PartnerBriefDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPartnersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<PartnerBriefDto>> Handle(GetPartnersWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Partners
                .Where(x => x.PartnerID == request.PartnerID)
                .OrderBy(x => x.PartnerName)
                .ProjectTo<PartnerBriefDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}

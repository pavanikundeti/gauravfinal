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

namespace PartnerPortal.Application.Requisitions.Get_Requisition
{
    public class GetRequisitionbyIDQuery : IRequest<RequisitionVm>
    {
        public Guid RequisitionID { get; init; }
    }
    public class GetRequisitionbyIDQueryHandler : IRequestHandler<GetRequisitionbyIDQuery, RequisitionVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;



        public GetRequisitionbyIDQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<RequisitionVm> Handle(GetRequisitionbyIDQuery request, CancellationToken cancellationToken)
        {
            return new RequisitionVm
            {
                Lists = await _context.requisitions
                .Where(t => t.RequisitionID == request.RequisitionID)
                .ProjectTo<RequisitionDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken)
            };
        }
    }
}

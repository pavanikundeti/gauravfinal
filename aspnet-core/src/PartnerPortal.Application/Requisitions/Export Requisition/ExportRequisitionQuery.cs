using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.Requisitions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Export_Requisition
{
    public record ExportRequisitionQuery : IRequest<ExportRequisitionVM>
    {
        public Guid RequisitionID { get; init; }
    }

    public class ExportRequisitionQueryHandler : IRequestHandler<ExportRequisitionQuery, ExportRequisitionVM>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportRequisitionQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportRequisitionVM> Handle(ExportRequisitionQuery request, CancellationToken cancellationToken)
        {
            var records = await _context.RequisitionSkills
                    .Where(t => t.RequisitionID == request.RequisitionID)
                    .ProjectTo<RequisitionRecord>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            var vm = new ExportRequisitionVM(
                "Requisition.csv",
                "text/csv",
                _fileBuilder.BuildRequisitionsFile(records));

            return vm;
        }
    }
}

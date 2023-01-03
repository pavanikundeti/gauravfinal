using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Commands
{
    public record CreateRequisitionFilesCommand : IRequest<int>
    {
        public Guid RequisitionFileID { get; set; }
        public Guid RequisitionID { get; set; }
        public String FileName { get; set; }
        public String FileTypeDescription { get; set; }
    }

    public class CreateRequisitionFilesCommandHandler : IRequestHandler<CreateRequisitionFilesCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRequisitionFilesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRequisitionFilesCommand request, CancellationToken cancellationToken)
        {
            var entity = new RequisitionFile
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                RequisitionID = request.RequisitionID,
                FileName = request.FileName,
                FileTypeDescription = request.FileTypeDescription,
            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.RequisitionFiles.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}

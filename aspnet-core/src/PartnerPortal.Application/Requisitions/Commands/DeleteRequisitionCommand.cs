using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Requisitions.Commands
{
    public record DeleteRequisitionCommand(Guid Id) : IRequest;

    public class DeleteRequisitionCommandHandler : IRequestHandler<DeleteRequisitionCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRequisitionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRequisitionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.requisitions
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Requisition), request.Id);
            }

            _context.requisitions.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.TodoItems.Commands;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Partners.Commands
{
    public record DeletePartnerCommand(Guid Id) : IRequest;
    public class DeletePartnerCommandHandler: IRequestHandler<DeletePartnerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePartnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Partners
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Partner), request.Id);
            }

            _context.Partners.Remove(entity);

/*            entity.AddDomainEvent(new PartnerDeletedEvent(entity));
*/
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


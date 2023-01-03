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

namespace PartnerPortal.Application.ProjectManagers.Commands
{
    public record DeleteProjectManagerCommand(Guid Id) : IRequest;
    public class DeleteProjectManagerCommandHandler : IRequestHandler<DeleteProjectManagerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProjectManagerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteProjectManagerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProjectManagers
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectManager), request.Id);
            }

            _context.ProjectManagers.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }

}

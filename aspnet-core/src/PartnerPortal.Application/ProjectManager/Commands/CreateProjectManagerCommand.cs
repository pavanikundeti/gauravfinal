using MediatR;
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
    public record CreateProjectManagerCommand : IRequest<int>
    {
        public Guid ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }
        public string EmployeeID { get; set; }
        public DateTime JoiningDate { get; set; }
        public string PMEmailID { get; set; }
        public string PMPhoneNumber { get; set; }
        public byte[] PMPhoto { get; set; }
        public Int16 PMStatus { get; set; }
        public Guid? PMUserID { get; set; }
    }

    public class CreateProjectManagerCommandHandler : IRequestHandler<CreateProjectManagerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProjectManagerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProjectManagerCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProjectManager
            {

                ProjectManagerName = request.ProjectManagerName,
                EmployeeID = request.EmployeeID,
                JoiningDate = request.JoiningDate,
                PMEmailID = request.PMEmailID,
                PMPhoneNumber = request.PMPhoneNumber,
                PMPhoto = request.PMPhoto,
                PMStatus = request.PMStatus,
                PMUserID = request.PMUserID,
               

            };

            //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            _context.ProjectManagers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}

using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record CreateSkillsCommand : IRequest<int>
    {
        public Guid SkillID { get; set; }
        public string SkillName { get; set; }
       
    }



    public class CreateSkillsCommandHandler : IRequestHandler<CreateSkillsCommand, int>
    {
        private readonly IApplicationDbContext _context;



        public CreateSkillsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<int> Handle(CreateSkillsCommand request, CancellationToken cancellationToken)
        {
            var entity = new Skill
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                SkillID = request.SkillID,
                SkillName = request.SkillName,
               



            };



            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));



            _context.Skills.Add(entity);



            await _context.SaveChangesAsync(cancellationToken);



            //return request.DepartmentID;
            return 1;



        }
    }
}

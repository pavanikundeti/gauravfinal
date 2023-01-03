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

namespace PartnerPortal.Application.Partners.Commands
{
    public record CreatePartnerCommand : IRequest<int>
    {
        public Guid PartnerID { get; set; }
        public string PartnerName { get; set; }
        public string Location { get; set; }
        public Guid? CountryID { get; set; }
        public DateTime RegisteredDate { get; set; }
        public Guid? SPOCUserID { get; set; }
        public string Address1 { get; set; }
        public string BillingAddress1 { get; set; }
        public byte[] PartnerImage { get; set; }
        public int PartnerStatus { get; set; }
       
    }
    public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
          
            var entity = new Partner
            {
                //ListId = request.ListId,
                //Title = request.Title,
                //Done = false
                PartnerName= request.PartnerName,
                Location= request.Location,
                CountryID= (Guid)request.CountryID,
                RegisteredDate= request.RegisteredDate,
                SPOCUserID= request.SPOCUserID,
                Address1= request.Address1,
                BillingAddress1= request.BillingAddress1,
                PartnerImage= request.PartnerImage,
                PartnerStatus= request.PartnerStatus,
               


            };

            //entity.AddDomainEvent(new PartnerCreatedEvent(entity));

            _context.Partners.Add(entity);
            

            await _context.SaveChangesAsync(cancellationToken);

            return 1;
        }
    }
}

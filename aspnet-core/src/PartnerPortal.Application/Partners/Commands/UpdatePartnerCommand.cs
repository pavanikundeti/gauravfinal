using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.TodoItems.Commands;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Partners.Commands
{
    public class UpdatePartnerCommand: IRequest
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
/*        public Guid id { get; set; }
*/    }
    public class UpdatePartnerCommandHandler : IRequestHandler<UpdatePartnerCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePartnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Partners
                .FindAsync(new object[] { request.PartnerID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Partner), request.PartnerID);
            }

            entity.PartnerID = request.PartnerID;
            entity.PartnerName = request.PartnerName;
            entity.Location = request.Location;
            entity.CountryID =(Guid) request.CountryID;
            entity.RegisteredDate = request.RegisteredDate;
            entity.SPOCUserID = request.SPOCUserID;
            entity.Address1 = request.Address1;
            entity.BillingAddress1 = request.BillingAddress1;
            entity.PartnerImage = request.PartnerImage;
            entity.PartnerStatus = request.PartnerStatus;


            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

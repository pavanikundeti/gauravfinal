using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;
using System.Runtime.Intrinsics.Arm;

namespace PartnerPortal.WebApi.Controllers
{
    public class CountryController : ApiControllerBase
    {
        private ApplicationDbContext ApplicationDbContext_context;
        public CountryController(ApplicationDbContext AppDBcontext)
        {
            ApplicationDbContext_context = AppDBcontext;
        }

        [HttpGet]
        public Country[] Get()
        {
            var listofCountry = ApplicationDbContext_context.Countries.ToList();
            return listofCountry.ToArray();


        }

        
    }


}


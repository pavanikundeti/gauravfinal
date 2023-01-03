using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Persistence;

namespace PartnerPortal.WebApi.Controllers
{
    public class DepartmentController : ApiControllerBase
    {
        private ApplicationDbContext ApplicationDbContext_context;
        public DepartmentController(ApplicationDbContext AppDBcontext)
        {
            ApplicationDbContext_context = AppDBcontext;
        }

        [HttpGet]
        public Department[] GetDepartment()
        {
            var listofdepartment = ApplicationDbContext_context.Departments.ToList();
            return listofdepartment.ToArray();


        }

        [HttpGet("Currency")]
        public Currency[] GetCurrency()
        {
            var listofcurrency = ApplicationDbContext_context.Currencies.ToList();
            return listofcurrency.ToArray();


        }
    }
}

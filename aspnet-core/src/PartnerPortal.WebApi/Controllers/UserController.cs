using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Identity;
using PartnerPortal.Infrastructure.Persistence;
using System.Net.Http.Headers;
using Response = PartnerPortal.Domain.Entities.Response;

namespace PartnerPortal.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public UserController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            //_emailService = emailService;
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProfileByUserID(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roleIdUserIDCombo = await _dbContext.UserRoles.Where(x => x.UserId == id).FirstOrDefaultAsync();
            var roleId = roleIdUserIDCombo.RoleId;
            var role = await _roleManager.FindByIdAsync(roleId);

            if (role.Name == "Administrator")
            {

                return StatusCode(StatusCodes.Status200OK,
                    new UserProfile
                    {
                        UserName= user.UserName,
                        Email=user.Email,
                        CompanyName="Flatworld Solutions",
                        Address="Indiranagar",
                        ContactNumber="7362889401",
                        Password=user.PasswordHash
                    });
            }
            if (role.Name == "ProjectManager")
            {

                return StatusCode(StatusCodes.Status200OK,
                    new UserProfile
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        CompanyName = "Flatworld Solutions",
                        Address = "Hennur",
                        ContactNumber = "8722053831",
                        Password = user.PasswordHash
                    });
            }
            else
            {
                var partner=await _dbContext.Partners.Where(p=>p.SPOCUserID.ToString()==id).FirstOrDefaultAsync();
               return StatusCode(StatusCodes.Status200OK,
               new UserProfile
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    CompanyName = partner.PartnerName,
                    Address = partner.Address1,
                    ContactNumber = "7362889401",
                    Password = user.PasswordHash
                });
            }

        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload(Image img)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return NoContent();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutUser(Guid id, UserProfile user)
        {
            var u = await _userManager.FindByIdAsync(id.ToString());
            var roleIdUserIDCombo = await _dbContext.UserRoles.Where(x => x.UserId == id.ToString()).FirstOrDefaultAsync();
            var roleId = roleIdUserIDCombo.RoleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.PasswordHash = user.Password;
            _dbContext.Entry(u).State = EntityState.Modified;
             if (role.Name == "Administrator")
            {
                //yet to add
            }
            if (role.Name == "ProjectManager")
            {
                //yet to add
            }
            else
            {
                var partner=await _dbContext.Partners.Where(p=>p.SPOCUserID==id).FirstOrDefaultAsync();
                if (partner == null)
                {
                    await _dbContext.SaveChangesAsync();
                    return NoContent();
                }
                partner.PartnerName = user.CompanyName;
                partner.Address1 = user.Address;
                _dbContext.Entry(partner).State = EntityState.Modified;

            }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return NoContent();
        }
    }
}

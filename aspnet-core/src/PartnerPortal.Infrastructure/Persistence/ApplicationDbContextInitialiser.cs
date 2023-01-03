using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Infrastructure.Identity;

namespace PartnerPortal.Infrastructure.Persistence
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                   // await _context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default roles
            var administratorRole = new IdentityRole("Administrator");

            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
            }

            // Default users
            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (_userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await _userManager.CreateAsync(administrator, "Administrator1!");
                await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
            }

            // Default data
            // Seed, if necessary
            if (!_context.TodoLists.Any())
            {
                _context.TodoLists.Add(new TodoList
                {
                    Title = "Todo List",
                    Items =
                {
                    new TodoItem { Title = "Make a todo list 📃" },
                    new TodoItem { Title = "Check off the first item ✅" },
                    new TodoItem { Title = "Realise you've already done two things on the list! 🤯"},
                    new TodoItem { Title = "Reward yourself with a nice, long nap 🏆" },
                }
                });

                await _context.SaveChangesAsync();
            }
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country() { CountryName = "Afghanistan" });
                _context.Countries.Add(new Country() { CountryName = "Åland Islands" });
                _context.Countries.Add(new Country() { CountryName = "Albania" });
                _context.Countries.Add(new Country() { CountryName = "Algeria" });
                _context.Countries.Add(new Country() { CountryName = "American Samoa" });
                _context.Countries.Add(new Country() { CountryName = "Andorra" });
                _context.Countries.Add(new Country() { CountryName = "Angola" });
                _context.Countries.Add(new Country() { CountryName = "Anguilla" });
                _context.Countries.Add(new Country() { CountryName = "Antarctica" });
                _context.Countries.Add(new Country() { CountryName = "Antigua and Barbuda" });
                _context.Countries.Add(new Country() { CountryName = "Argentina" });
                _context.Countries.Add(new Country() { CountryName = "Armenia" });
                _context.Countries.Add(new Country() { CountryName = "Aruba" });
                _context.Countries.Add(new Country() { CountryName = "Australia" });
                _context.Countries.Add(new Country() { CountryName = "Austria" });
                _context.Countries.Add(new Country() { CountryName = "Azerbaijan" });
                _context.Countries.Add(new Country() { CountryName = "Bahamas" });
                _context.Countries.Add(new Country() { CountryName = "Bahrain" });
                _context.Countries.Add(new Country() { CountryName = "Bangladesh" });
                _context.Countries.Add(new Country() { CountryName = "Barbados" });
                _context.Countries.Add(new Country() { CountryName = "Belarus" });
                _context.Countries.Add(new Country() { CountryName = "Belgium" });
                _context.Countries.Add(new Country() { CountryName = "Belize" });
                _context.Countries.Add(new Country() { CountryName = "Benin" });
                _context.Countries.Add(new Country() { CountryName = "Bermuda" });
                _context.Countries.Add(new Country() { CountryName = "Bhutan" });
                _context.Countries.Add(new Country() { CountryName = "Bolivia" });
                _context.Countries.Add(new Country() { CountryName = "Bosnia and Herzegovina" });
                _context.Countries.Add(new Country() { CountryName = "Botswana" });
                _context.Countries.Add(new Country() { CountryName = "Bouvet Island" });
                _context.Countries.Add(new Country() { CountryName = "Brazil" });
                _context.Countries.Add(new Country() { CountryName = "British Indian Ocean Territory" });
                _context.Countries.Add(new Country() { CountryName = "Brunei Darussalam" });
                _context.Countries.Add(new Country() { CountryName = "Bulgaria" });
                _context.Countries.Add(new Country() { CountryName = "Burkina Faso" });
                _context.Countries.Add(new Country() { CountryName = "Burundi" });
                _context.Countries.Add(new Country() { CountryName = "Cambodia" });
                _context.Countries.Add(new Country() { CountryName = "Cameroon" });
                _context.Countries.Add(new Country() { CountryName = "Canada" });
                _context.Countries.Add(new Country() { CountryName = "Cape Verde" });
                _context.Countries.Add(new Country() { CountryName = "Cayman Islands" });
                _context.Countries.Add(new Country() { CountryName = "Central African Republic" });
                _context.Countries.Add(new Country() { CountryName = "Chad" });
                _context.Countries.Add(new Country() { CountryName = "Chile" });
                _context.Countries.Add(new Country() { CountryName = "China" });
                _context.Countries.Add(new Country() { CountryName = "Christmas Island" });
                _context.Countries.Add(new Country() { CountryName = "Cocos (Keeling) Islands" });
                _context.Countries.Add(new Country() { CountryName = "Colombia" });
                _context.Countries.Add(new Country() { CountryName = "Comoros" });
                _context.Countries.Add(new Country() { CountryName = "Congo" });
                _context.Countries.Add(new Country() { CountryName = "Cook Islands" });
                _context.Countries.Add(new Country() { CountryName = "Costa Rica" });
                _context.Countries.Add(new Country() { CountryName = "Cote D'ivoire" });
                _context.Countries.Add(new Country() { CountryName = "Croatia" });
                _context.Countries.Add(new Country() { CountryName = "Cuba" });
                _context.Countries.Add(new Country() { CountryName = "Cyprus" });
                _context.Countries.Add(new Country() { CountryName = "Czech Republic" });
                _context.Countries.Add(new Country() { CountryName = "Denmark" });
                _context.Countries.Add(new Country() { CountryName = "Djibouti" });
                _context.Countries.Add(new Country() { CountryName = "Dominica" });
                _context.Countries.Add(new Country() { CountryName = "Dominican Republic" });
                _context.Countries.Add(new Country() { CountryName = "Ecuador" });
                _context.Countries.Add(new Country() { CountryName = "Egypt" });
                _context.Countries.Add(new Country() { CountryName = "El Salvador" });
                _context.Countries.Add(new Country() { CountryName = "Equatorial Guinea" });
                _context.Countries.Add(new Country() { CountryName = "Eritrea" });
                _context.Countries.Add(new Country() { CountryName = "Estonia" });
                _context.Countries.Add(new Country() { CountryName = "Ethiopia" });
                _context.Countries.Add(new Country() { CountryName = "Falkland Islands (Malvinas)" });
                _context.Countries.Add(new Country() { CountryName = "Faroe Islands" });
                _context.Countries.Add(new Country() { CountryName = "Fiji" });
                _context.Countries.Add(new Country() { CountryName = "Finland" });
                _context.Countries.Add(new Country() { CountryName = "France" });
                _context.Countries.Add(new Country() { CountryName = "French Guiana" });
                _context.Countries.Add(new Country() { CountryName = "French Polynesia" });
                _context.Countries.Add(new Country() { CountryName = "French Southern Territories" });
                _context.Countries.Add(new Country() { CountryName = "Gabon" });
                _context.Countries.Add(new Country() { CountryName = "Gambia" });
                _context.Countries.Add(new Country() { CountryName = "Georgia" });
                _context.Countries.Add(new Country() { CountryName = "Germany" });
                _context.Countries.Add(new Country() { CountryName = "Ghana" });
                _context.Countries.Add(new Country() { CountryName = "Gibraltar" });
                _context.Countries.Add(new Country() { CountryName = "Greece" });
                _context.Countries.Add(new Country() { CountryName = "Greenland" });
                _context.Countries.Add(new Country() { CountryName = "Grenada" });
                _context.Countries.Add(new Country() { CountryName = "Guadeloupe" });
                _context.Countries.Add(new Country() { CountryName = "Guam" });
                _context.Countries.Add(new Country() { CountryName = "Guatemala" });
                _context.Countries.Add(new Country() { CountryName = "Guernsey" });
                _context.Countries.Add(new Country() { CountryName = "Guinea" });
                _context.Countries.Add(new Country() { CountryName = "Guinea-bissau" });
                _context.Countries.Add(new Country() { CountryName = "Guyana" });
                _context.Countries.Add(new Country() { CountryName = "Haiti" });
                _context.Countries.Add(new Country() { CountryName = "Heard Island and Mcdonald Islands" });
                _context.Countries.Add(new Country() { CountryName = "Holy See (Vatican City State)" });
                _context.Countries.Add(new Country() { CountryName = "Honduras" });
                _context.Countries.Add(new Country() { CountryName = "Hong Kong" });
                _context.Countries.Add(new Country() { CountryName = "Hungary" });
                _context.Countries.Add(new Country() { CountryName = "Iceland" });
                _context.Countries.Add(new Country() { CountryName = "India" });
                _context.Countries.Add(new Country() { CountryName = "Indonesia" });
                _context.Countries.Add(new Country() { CountryName = "Iran, Islamic Republic of" });
                _context.Countries.Add(new Country() { CountryName = "Iraq" });
                _context.Countries.Add(new Country() { CountryName = "Ireland" });
                _context.Countries.Add(new Country() { CountryName = "Isle of Man" });
                _context.Countries.Add(new Country() { CountryName = "Israel" });
                _context.Countries.Add(new Country() { CountryName = "Italy" });
                _context.Countries.Add(new Country() { CountryName = "Jamaica" });
                _context.Countries.Add(new Country() { CountryName = "Japan" });
                _context.Countries.Add(new Country() { CountryName = "Jersey" });
                _context.Countries.Add(new Country() { CountryName = "Jordan" });
                _context.Countries.Add(new Country() { CountryName = "Kazakhstan" });
                _context.Countries.Add(new Country() { CountryName = "Kenya" });
                _context.Countries.Add(new Country() { CountryName = "Kiribati" });
                _context.Countries.Add(new Country() { CountryName = "South Korea" });
                _context.Countries.Add(new Country() { CountryName = "North Korea" });
                _context.Countries.Add(new Country() { CountryName = "Kuwait" });
                _context.Countries.Add(new Country() { CountryName = "Kyrgyzstan" });
                _context.Countries.Add(new Country() { CountryName = "Lao People's Democratic Republic" });
                _context.Countries.Add(new Country() { CountryName = "Latvia" });
                _context.Countries.Add(new Country() { CountryName = "Lebanon" });
                _context.Countries.Add(new Country() { CountryName = "Lesotho" });
                _context.Countries.Add(new Country() { CountryName = "Liberia" });
                _context.Countries.Add(new Country() { CountryName = "Libyan Arab Jamahiriya" });
                _context.Countries.Add(new Country() { CountryName = "Liechtenstein" });
                _context.Countries.Add(new Country() { CountryName = "Lithuania" });
                _context.Countries.Add(new Country() { CountryName = "Luxembourg" });
                _context.Countries.Add(new Country() { CountryName = "Macao" });
                _context.Countries.Add(new Country() { CountryName = "Macedonia" });
                _context.Countries.Add(new Country() { CountryName = "Madagascar" });
                _context.Countries.Add(new Country() { CountryName = "Malawi" });
                _context.Countries.Add(new Country() { CountryName = "Malaysia" });
                _context.Countries.Add(new Country() { CountryName = "Maldives" });
                _context.Countries.Add(new Country() { CountryName = "Mali" });
                _context.Countries.Add(new Country() { CountryName = "Malta" });
                _context.Countries.Add(new Country() { CountryName = "Marshall Islands" });
                _context.Countries.Add(new Country() { CountryName = "Martinique" });
                _context.Countries.Add(new Country() { CountryName = "Mauritania" });
                _context.Countries.Add(new Country() { CountryName = "Mauritius" });
                _context.Countries.Add(new Country() { CountryName = "Mayotte" });
                _context.Countries.Add(new Country() { CountryName = "Mexico" });
                _context.Countries.Add(new Country() { CountryName = "Micronesia" });
                _context.Countries.Add(new Country() { CountryName = "Moldova" });
                _context.Countries.Add(new Country() { CountryName = "Monaco" });
                _context.Countries.Add(new Country() { CountryName = "Mongolia" });
                _context.Countries.Add(new Country() { CountryName = "Montenegro" });
                _context.Countries.Add(new Country() { CountryName = "Montserrat" });
                _context.Countries.Add(new Country() { CountryName = "Morocco" });
                _context.Countries.Add(new Country() { CountryName = "Mozambique" });
                _context.Countries.Add(new Country() { CountryName = "Myanmar" });
                _context.Countries.Add(new Country() { CountryName = "Namibia" });
                _context.Countries.Add(new Country() { CountryName = "Nauru" });
                _context.Countries.Add(new Country() { CountryName = "Nepal" });
                _context.Countries.Add(new Country() { CountryName = "Netherlands" });
                _context.Countries.Add(new Country() { CountryName = "Netherlands Antilles" });
                _context.Countries.Add(new Country() { CountryName = "New Caledonia" });
                _context.Countries.Add(new Country() { CountryName = "New Zealand" });
                _context.Countries.Add(new Country() { CountryName = "Nicaragua" });
                _context.Countries.Add(new Country() { CountryName = "Niger" });
                _context.Countries.Add(new Country() { CountryName = "Nigeria" });
                _context.Countries.Add(new Country() { CountryName = "Niue" });
                _context.Countries.Add(new Country() { CountryName = "Norfolk Island" });
                _context.Countries.Add(new Country() { CountryName = "Northern Mariana Islands" });
                _context.Countries.Add(new Country() { CountryName = "Norway" });
                _context.Countries.Add(new Country() { CountryName = "Oman" });
                _context.Countries.Add(new Country() { CountryName = "Pakistan" });
                _context.Countries.Add(new Country() { CountryName = "Palau" });
                _context.Countries.Add(new Country() { CountryName = "Palestinian Territory, Occupied" });
                _context.Countries.Add(new Country() { CountryName = "Panama" });
                _context.Countries.Add(new Country() { CountryName = "Papua New Guinea" });
                _context.Countries.Add(new Country() { CountryName = "Paraguay" });
                _context.Countries.Add(new Country() { CountryName = "Peru" });
                _context.Countries.Add(new Country() { CountryName = "Philippines" });
                _context.Countries.Add(new Country() { CountryName = "Pitcairn" });
                _context.Countries.Add(new Country() { CountryName = "Poland" });
                _context.Countries.Add(new Country() { CountryName = "Portugal" });
                _context.Countries.Add(new Country() { CountryName = "Puerto Rico" });
                _context.Countries.Add(new Country() { CountryName = "Qatar" });
                _context.Countries.Add(new Country() { CountryName = "Reunion" });
                _context.Countries.Add(new Country() { CountryName = "Romania" });
                _context.Countries.Add(new Country() { CountryName = "Russian Federation" });
                _context.Countries.Add(new Country() { CountryName = "Rwanda" });
                _context.Countries.Add(new Country() { CountryName = "Saint Helena" });
                _context.Countries.Add(new Country() { CountryName = "Saint Kitts and Nevis" });
                _context.Countries.Add(new Country() { CountryName = "Saint Lucia" });
                _context.Countries.Add(new Country() { CountryName = "Saint Pierre and Miquelon" });
                _context.Countries.Add(new Country() { CountryName = "Saint Vincent and The Grenadines" });
                _context.Countries.Add(new Country() { CountryName = "Samoa" });
                _context.Countries.Add(new Country() { CountryName = "San Marino" });
                _context.Countries.Add(new Country() { CountryName = "Sao Tome and Principe" });
                _context.Countries.Add(new Country() { CountryName = "Saudi Arabia" });
                _context.Countries.Add(new Country() { CountryName = "Senegal" });
                _context.Countries.Add(new Country() { CountryName = "Serbia" });
                _context.Countries.Add(new Country() { CountryName = "Seychelles" });
                _context.Countries.Add(new Country() { CountryName = "Sierra Leone" });
                _context.Countries.Add(new Country() { CountryName = "Singapore" });
                _context.Countries.Add(new Country() { CountryName = "Slovenia" });
                _context.Countries.Add(new Country() { CountryName = ">Solomon Islands" });
                _context.Countries.Add(new Country() { CountryName = "Somalia" });
                _context.Countries.Add(new Country() { CountryName = "South Africa" });
                _context.Countries.Add(new Country() { CountryName = "South Georgia and The South Sandwich Islands" });
                _context.Countries.Add(new Country() { CountryName = "Spain" });
                _context.Countries.Add(new Country() { CountryName = "Sri Lanka" });
                _context.Countries.Add(new Country() { CountryName = "Sudan" });
                _context.Countries.Add(new Country() { CountryName = "Suriname" });
                _context.Countries.Add(new Country() { CountryName = "Svalbard and Jan Mayen" });
                _context.Countries.Add(new Country() { CountryName = "Swaziland" });
                _context.Countries.Add(new Country() { CountryName = "Swaziland" });
                _context.Countries.Add(new Country() { CountryName = "Switzerland" });
                _context.Countries.Add(new Country() { CountryName = "Syrian Arab Republic" });
                _context.Countries.Add(new Country() { CountryName = "Taiwan" });
                _context.Countries.Add(new Country() { CountryName = "Tanzania, United Republic of" });
                _context.Countries.Add(new Country() { CountryName = "Thailand" });
                _context.Countries.Add(new Country() { CountryName = "Timor-leste" });
                _context.Countries.Add(new Country() { CountryName = "Togo" });
                _context.Countries.Add(new Country() { CountryName = "Tokelau" });
                _context.Countries.Add(new Country() { CountryName = "Tonga" });
                _context.Countries.Add(new Country() { CountryName = "Trinidad and Tobago" });
                _context.Countries.Add(new Country() { CountryName = "Tunisia" });
                _context.Countries.Add(new Country() { CountryName = "Turkey" });
                _context.Countries.Add(new Country() { CountryName = "Turkmenistan" });
                _context.Countries.Add(new Country() { CountryName = "Turks and Caicos Islands" });
                _context.Countries.Add(new Country() { CountryName = "Tuvalu" });
                _context.Countries.Add(new Country() { CountryName = "Uganda" });
                _context.Countries.Add(new Country() { CountryName = "Ukraine" });
                _context.Countries.Add(new Country() { CountryName = "United Arab Emirate);s" });
                _context.Countries.Add(new Country() { CountryName = "United Kingdom" });
                _context.Countries.Add(new Country() { CountryName = "United States" });
                _context.Countries.Add(new Country() { CountryName = "United States Minor Outlying Islands" });
                _context.Countries.Add(new Country() { CountryName = "Uruguay" });
                _context.Countries.Add(new Country() { CountryName = "Uzbekistan" });
                _context.Countries.Add(new Country() { CountryName = "Vanuatu" });
                _context.Countries.Add(new Country() { CountryName = "Venezuela" });
                _context.Countries.Add(new Country() { CountryName = "Viet Nam" });
                _context.Countries.Add(new Country() { CountryName = "Virgin Islands, British" });
                _context.Countries.Add(new Country() { CountryName = "Virgin Islands, U.S." });
                _context.Countries.Add(new Country() { CountryName = "Wallis and Futuna" });
                _context.Countries.Add(new Country() { CountryName = "Western Sahara" });
                _context.Countries.Add(new Country() { CountryName = "Yemen" });
                _context.Countries.Add(new Country() { CountryName = "Zambia" });
                _context.Countries.Add(new Country() { CountryName = "Zimbabwe" });

                await _context.SaveChangesAsync();
            }
            if (!_context.Departments.Any())
            {
                _context.Departments.Add(new Department() { DepartmentName = "Mortgage" });
                _context.Departments.Add(new Department() { DepartmentName = "Software" });

                await _context.SaveChangesAsync();
            }
            if (!_context.Currencies.Any())
            {
                _context.Currencies.Add(new Currency() { CurrencyName = "INR" });
                _context.Currencies.Add(new Currency() { CurrencyName = "USD" });

                await _context.SaveChangesAsync();
            }
        }
    }
}

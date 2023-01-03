using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
	public class Users
	{
		public string? Id { get; set; }

		[Required(ErrorMessage = "User Name is required")]
		public string? Username { get; set; }

		[EmailAddress]
		[Required(ErrorMessage = "Email is required")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "PhoneNumber is required")]
		public string? PhoneNumber { get; set; }
	}
}

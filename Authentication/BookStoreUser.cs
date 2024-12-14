using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Authentication
{
	public class BookStoreUser : IdentityUser
	{
		[DisplayName("Full Name")]
		[MaxLength(128)]
		[Required]
		public string? FullName { get; set; }
	}
}

using Microsoft.AspNetCore.Http;
namespace TraverselCore.Areas.Member.Models
{
	public class UserEditViemModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string ImageUrl { get; set; }
		public IFormFile Image { get; set; }

	}
}

using System.ComponentModel.DataAnnotations;

namespace TraverselCore.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen adınızı giriniz.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
		public string SurName { get; set; }

		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz.")]
		public string UserName { get; set; }
		// buradan başladı
		[Required(ErrorMessage = "Lütfen Cinsiyetinizi giriniz.")]
		public string? Gender { get; set; }

		[Required(ErrorMessage = "Lütfen Cinsiyetinizi giriniz.")]
		public string? ImageUrl { get; set; }
		// buraya kadar sonradan eklendi

		[Required(ErrorMessage = "Lütfen mail adresinizi giriniz.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz.")]
		[Compare("Password", ErrorMessage = "Şifreler uyumlu değil, tekrar deneyiniz")]
		public string ConfirmPassword { get; set; }


		




	}
}

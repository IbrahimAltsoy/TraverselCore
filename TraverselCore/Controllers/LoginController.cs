using EntityLayer.Concreate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraverselCore.Models;

namespace TraverselCore.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
		private readonly UserManager<AppUser> userManager;
		private readonly SignInManager<AppUser> signInManager;

		public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}
		[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel appUser)
        {
            AppUser user = new AppUser()
            {
                Name = appUser.Name,
                Surname = appUser.SurName,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Gender= appUser.Gender,
                ImageUrl= appUser.ImageUrl,
                PasswordHash = appUser.Password
                

            };
			
			if (appUser.Password==appUser.ConfirmPassword)
            {
                var result = await userManager.CreateAsync(user, appUser.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }


			return View(appUser);
		}
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

    }
}

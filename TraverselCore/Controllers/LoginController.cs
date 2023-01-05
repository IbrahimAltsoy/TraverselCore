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
        // Giriş işlemleri
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel signInViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(signInViewModel.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, signInViewModel.Password, false, true);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Destination", new { Area = "Member" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlış girilmiştir.");
                        return View();
                    }
                }
                else
                {

                    ModelState.AddModelError("", "Kullanıcı adınız veya şifreniz yanlış girilmiştir.");
                    return View();
                }

            }
            else
            {
                return View();

            }

        }
        //[Authorize]
        //[HttpGet]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();

        //    return RedirectToAction("Index", "Home", new { Area = "" });
        //}

    }
}

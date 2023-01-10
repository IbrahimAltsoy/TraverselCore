using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.Areas.Member.Controllers
{
    [Area(nameof(Member))]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = model.Name + " " + model.Surname;
            ViewBag.userImage = model.ImageUrl;
            return View();
        }
    }
}

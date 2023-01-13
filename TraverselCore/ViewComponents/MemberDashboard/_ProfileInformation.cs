using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.MemberDashboard
{
    public class _ProfileInformation: ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _ProfileInformation(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = model.Name + " " + model.Surname;
            ViewBag.phone = model.PhoneNumber;
            ViewBag.email = model.Email;

            return View();
        }
    }
}

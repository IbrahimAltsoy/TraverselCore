using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraverselCore.Areas.Member.Models;

namespace TraverselCore.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfilController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfilController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViemModel userEditViemModel = new UserEditViemModel();
            userEditViemModel.Name = model.Name;
            userEditViemModel.Surname= model.Surname;
            userEditViemModel.PhoneNumber = model.PhoneNumber;
            userEditViemModel.ImageUrl = model.ImageUrl;
            userEditViemModel.Email = model.Email;
           
            return View(userEditViemModel);
        }
    }
}

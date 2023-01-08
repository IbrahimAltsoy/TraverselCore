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
            userEditViemModel.Surname = model.Surname;
            userEditViemModel.PhoneNumber = model.PhoneNumber;
            userEditViemModel.ImageUrl = model.ImageUrl;
            userEditViemModel.Email = model.Email;

            return View(userEditViemModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViemModel userEditViemModel)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (userEditViemModel.Image != null)
            {
                var research = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(userEditViemModel.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = research + "/wwwroot/userImage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await userEditViemModel.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;

            }
            user.Name = userEditViemModel.Name; 
            user.Surname = userEditViemModel.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViemModel.Password);
            var result = await _userManager.UpdateAsync(user);
           
            
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }
    }
}

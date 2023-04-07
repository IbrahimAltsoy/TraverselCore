using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraverselCore.Areas.Admin.Models;

namespace TraverselCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var model = _roleManager.Roles.ToList();
            return View(model);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateRoleViewModel role)
        {
            AppRole appRole = new AppRole()
            {
                Name = role.Name
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
           if (value == null)
            {
                return View("Error");
            }
            else
            {
                await _roleManager.DeleteAsync(value);
                return RedirectToAction(nameof(Index));
            }
            
        }
        [HttpGet]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleViewModel updateRoleView = new UpdateRoleViewModel
            {
                Id = value.Id,
                Name = value.Name
            };
            return View(updateRoleView);

        }
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(UpdateRoleViewModel updateRoleView)
        {
            var value = _roleManager.Roles.FirstOrDefault(x => x.Id == updateRoleView.Id);
            value.Name = updateRoleView.Name;
            await _roleManager.UpdateAsync(value);
            return RedirectToAction(nameof(Index)); 

        }
        [HttpGet]
        [Route("User")]
        public IActionResult User()
        {
            var model = _userManager.Users.ToList();
            return View(model);
        }
        [HttpPost]
        [Route("Assign/{id}")]
        public async Task<IActionResult> AssingRole(Guid id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssingViewModel> roleAssingViewModels= new List<RoleAssingViewModel>();
            foreach(var role in roles)
            {
                RoleAssingViewModel model = new RoleAssingViewModel();
                model.Id = role.Id;
                model.Name = role.Name;
                model.RoleExist = userRoles.Contains(role.Name);
                roleAssingViewModels.Add(model);
            }

            return View();
        }
    }
}

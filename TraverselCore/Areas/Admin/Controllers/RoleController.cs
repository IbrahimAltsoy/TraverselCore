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

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
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
    }
}

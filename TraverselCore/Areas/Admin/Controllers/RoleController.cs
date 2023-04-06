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
    }
}

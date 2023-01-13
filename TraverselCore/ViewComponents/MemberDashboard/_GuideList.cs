using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.MemberDashboard
{
    public class _GuideList:ViewComponent
    {
        private readonly IService<Guide> _service1;
        public _GuideList(IService<Guide> service1)
        {
            _service1 = service1;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _service1.GetAllAsync();
            return View(model);
        }
    }
}

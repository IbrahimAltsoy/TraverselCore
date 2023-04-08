using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.MemberDashboard
{
    public class _CheapDestination:ViewComponent
    {
        private readonly IService<Destination> _service1;
        public _CheapDestination(IService<Destination> service1)
        {
            _service1 = service1;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _service1.GetAllAsync();
            return View(model.Take(4).OrderByDescending(x=>x.Price).ToList());
        }
    }
}

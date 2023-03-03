using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.Default
{
    public class _PopulardectinationsPartial :ViewComponent
    {
        private readonly IService<EntityLayer.Concreate.Destination> _service;
        public _PopulardectinationsPartial(IService<EntityLayer.Concreate.Destination> service)
        {
            this._service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = await _service.GetAllAsync(i => i.Price > 3000);
            //return View(model.Take(5));
            var model = await _service.GetAllAsync();


            return View(model);
        }
    }
}

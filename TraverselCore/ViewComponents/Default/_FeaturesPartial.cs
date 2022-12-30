using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.Default
{
    public class _FeaturesPartial : ViewComponent
    {
        private readonly IService<Feature> _service;
        public _FeaturesPartial(IService<Feature> service)
        {
            this._service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _service.GetAllAsync();

            // D662EF5B - A23F - 4AAC - 94EA - 44973ABE95F1
            //[Guid("4D265271-70A1-47E7-825A-68AC210E8BA1")]
            return View(model);
        }
    }

}

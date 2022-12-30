using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.Default
{
    


    public class _TestimonialPartial:ViewComponent
    {
        private readonly IService<Testimonial> _service;

        public _TestimonialPartial(IService<Testimonial> service)
        {
            this._service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _service.GetAllAsync();
            var model2 = model.Take(4).ToList();
            return View(model2);
        }

    }
}

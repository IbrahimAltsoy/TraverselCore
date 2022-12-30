using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.Default
{
    


    public class _TestimonialPartial:ViewComponent
    {
        private readonly IService<SubAbout> _service;

        public _TestimonialPartial(IService<SubAbout> service)
        {
            this._service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //var model = await _service.GetAllAsync();
            return View();
        }

    }
}

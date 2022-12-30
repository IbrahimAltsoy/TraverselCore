using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace TraverselCore.ViewComponents.Default
{
    public class _SubAboutPartial :ViewComponent
    {
       // [Guid("1120C851-8EF9-3ADF-B234-99C7C8ED5562")]

        private readonly IService<SubAbout> _service;        

        public _SubAboutPartial(IService<SubAbout> service)
        {
            this._service = service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model =await  _service.GetAllAsync();
            return View(model);
        }

    }
}

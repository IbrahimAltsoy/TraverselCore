using BusiinessLayer.Abstract;
using BusiinessLayer.Contcreate;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace TraverselCore.ViewComponents.Yorumlar
{
    public class _YorumEkle:ViewComponent
    {
        private readonly IService<Destination> service1;
        private readonly IService<Comment> _service2;
     
        public _YorumEkle(IService<Destination> service, IService<Comment> service2)
        {
            service1= service;
            _service2= service2;
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View();
        }


    }
}

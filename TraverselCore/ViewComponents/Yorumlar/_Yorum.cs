﻿using BusiinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
namespace TraverselCore.ViewComponents.Yorumlar
{
    public class _Yorum :ViewComponent
    {
        private readonly IService<Destination> _service;
        private readonly IService<Comment> _service1;

        public _Yorum(IService<Destination> service, IService<Comment> service1)
        {
            this._service = service;
            this._service1 = service1;
        }
        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync(Guid id)
        {
            var model = await _service.FindAsync(id);
            
            var model1 = await _service1.GetAllAsync(x=>x.DestinationId==id);
           
            return View(model1);

        }


    }
}
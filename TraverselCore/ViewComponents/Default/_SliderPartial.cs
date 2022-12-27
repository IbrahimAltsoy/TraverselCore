using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.Default
{
    //[ViewComponent(Name = "Default")]
    public class _SliderPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }



    }
}

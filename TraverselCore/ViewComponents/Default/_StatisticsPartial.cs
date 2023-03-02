using BusiinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.Default
{
    public class _StatisticsPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = new Context();
            //using var count = new Context(); bu kullanım da doğrudur 
            ViewBag.c1 = count.Destinations.Count();
            ViewBag.c2 = count.Guides.Count();
            ViewBag.c3 = "1285";
            ViewBag.c4 = "36";

            return View();
        }
    }
}

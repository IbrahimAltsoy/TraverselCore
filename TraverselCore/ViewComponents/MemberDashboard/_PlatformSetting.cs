using Microsoft.AspNetCore.Mvc;

namespace TraverselCore.ViewComponents.MemberDashboard
{
    public class _PlatformSetting:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}

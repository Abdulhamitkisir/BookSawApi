using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

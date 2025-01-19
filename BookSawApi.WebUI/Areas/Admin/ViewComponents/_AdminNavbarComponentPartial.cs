using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

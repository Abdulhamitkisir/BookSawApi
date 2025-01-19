using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

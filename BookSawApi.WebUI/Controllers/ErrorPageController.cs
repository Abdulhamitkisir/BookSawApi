using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult ErrorPage404()
        {
            return View();
        }
    }
}

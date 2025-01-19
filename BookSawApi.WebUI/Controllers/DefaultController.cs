using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

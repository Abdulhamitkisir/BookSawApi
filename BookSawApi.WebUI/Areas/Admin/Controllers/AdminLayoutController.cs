using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        [Area("Admin")]
        public IActionResult AdminLayout()
        {
            return View("AdminLayout");
        }
    }
}

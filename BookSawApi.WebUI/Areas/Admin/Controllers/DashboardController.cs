using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{

    public class DashboardController : Controller
    {
        [Area("Admin")]
        public  IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Areas.UI.Controllers
{
	public class UILayoutController : Controller
	{
		[Area("UI")]
		public IActionResult UILayout()
		{
			return View("UILayout");
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebUI.Areas.UI.ViewComponents
{
	public class _FooterComponentPartial: ViewComponent
	{
		public IViewComponentResult Invoke()
		{ 
			return View();
		}
	}
}

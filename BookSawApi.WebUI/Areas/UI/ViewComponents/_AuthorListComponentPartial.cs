using BookSawApi.WebUI.Dtos;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookSawApi.WebUI.Areas.UI.ViewComponents
{
	public class _AuthorListComponentPartial :ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AuthorListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responsesMessage = await client.GetAsync("https://localhost:7062/api/Author/GetAllAuthor");
			if (responsesMessage.IsSuccessStatusCode)
			{
				var jsondata = await responsesMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<AuthorListDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

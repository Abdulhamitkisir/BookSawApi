using BookSawApi.WebUI.Dtos.AuthorDtos;
using BookSawApi.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Security.Cryptography.X509Certificates;

namespace BookSawApi.WebUI.Areas.UI.ViewComponents
{
	public class _BookListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BookListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responsesMessage = await client.GetAsync("https://localhost:7062/api/Product/GetProductByCategory");
			if (responsesMessage.IsSuccessStatusCode)
			{
				var jsondata = await responsesMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ProductListDto>>(jsondata);
				return View(values);
			}
			return View();
		}
        public async Task<IViewComponentResult> InvokesAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Product/GetProductByCategory");
            if (responsesMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductListDto>>(jsondata);
                return View(values);
            }
            return View();
        }

    }
}

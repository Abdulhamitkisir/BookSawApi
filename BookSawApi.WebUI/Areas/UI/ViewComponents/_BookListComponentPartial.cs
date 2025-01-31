using BookSawApi.WebUI.Dtos.AuthorDtos;
using BookSawApi.WebUI.Dtos.CategoryDtos;
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


            var responseMessage = await client.GetAsync("https://localhost:7062/api/Category");


            if (responseMessage.IsSuccessStatusCode)
            {

                var jsonData = await responseMessage.Content.ReadAsStringAsync();


                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                return View(values);
            }


            return View();
        }
       

    }
}

using BookSawApi.WebUI.Dtos.ArticleDtos;
using BookSawApi.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookSawApi.WebUI.Areas.UI.ViewComponents
{
	public class _FeaturComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _FeaturComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public  async Task<IViewComponentResult> InvokeAsync()
		{

            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Article/GetLastArticle");
            if (responsesMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ArticleListDto>>(jsondata);
                return View(values);
            }
            return View();
        }
	}
}

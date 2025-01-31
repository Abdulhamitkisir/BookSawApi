using BookSawApi.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookSawApi.WebUI.Areas.UI.ViewComponents
{
    public class _AllBookWithCategoryComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AllBookWithCategoryComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Product/GetBookWithCategoryId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductListDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

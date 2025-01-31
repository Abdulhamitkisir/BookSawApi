using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BookSawApi.WebUI.Dtos.ProductDtos;

namespace BookSawApi.WebUI.Areas.UI.ViewComponents
{
    public class _AllBookListComponentPartial :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AllBookListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Product/ProductList");

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

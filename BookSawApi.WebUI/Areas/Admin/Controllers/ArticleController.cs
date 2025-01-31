using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using BookSawApi.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ArticleList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Article/GelAllArticle");
            if (responsesMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ArticleListDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createArticleDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responMessage = await client.PostAsync("https://localhost:7062/api/Article/CreateArticle", stringContent);
            if (responMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ArticleList");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7062/api/Article/ArticleGetById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ArticleListDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateArticle(ArticleListDto articleListDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(articleListDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7062/api/Article/UpdateArticle", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Article/ArticleList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7062/api/Article/DeleteArticle?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Article/ArticleList");
            }
            return View();
        }
    }
}

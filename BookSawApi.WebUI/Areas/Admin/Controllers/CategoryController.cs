using BookSawApi.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Category");
            if (responsesMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesssage = await client.GetAsync("https://localhost:7062/api/Category/GetById?id=" + id);
            if (responseMesssage.IsSuccessStatusCode)
            {
                var jsondata = await responseMesssage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultCategoryDto>(jsondata);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(ResultCategoryDto resultCategoryDto)
        { 
            var clinet= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(resultCategoryDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage=await clinet.PutAsync("https://localhost:7062/api/Category/Update",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7062/api/Category/Create", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/CategoryList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7062/api/Category/Delete?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Category/CategoryList");
            }
            return View();

        }
    }
}

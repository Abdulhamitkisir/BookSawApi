using BookSawApi.WebUI.Dtos;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net.Http;
using System.Text;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AuthorList()
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
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7062/api/Author/Delete?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Author/AuthorList");
            }
            return View();

        }
        [HttpGet]
        public IActionResult CreateAuthor()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var client= _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createAuthorDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responMessage = await client.PostAsync("https://localhost:7062/api/Author/CreateAuthor",stringContent);
            if (responMessage.IsSuccessStatusCode)
            { 
                return Redirect("/Admin/Author/AuthorList");
            }
            return View();
        }
    }
}

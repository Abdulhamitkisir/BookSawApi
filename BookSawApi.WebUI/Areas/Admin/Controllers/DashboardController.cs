using BookSawApi.WebUI.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller

    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Author/GetAllAuthor");
            if (responsesMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AuthorListDto>>(jsondata);

                // Toplam yazar sayısını hesaplama
                var totalAuthors = values?.Count ?? 0;

                ViewBag.TotalAuthors = totalAuthors; // Toplam yazar sayısını View'a taşıyabilirsiniz.
                return View(values);
            }
            return View();

        }
    }
}

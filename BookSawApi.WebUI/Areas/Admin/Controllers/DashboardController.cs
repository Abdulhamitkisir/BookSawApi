using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Identity;
using BookSawApi.WebUI.Dtos.ProductDtos;
using BookSawApi.WebUI.Dtos.CategoryDtos;
using BookSawApi.WebUI.Dtos.ArticleDtos;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller

    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
             

        public DashboardController(IHttpClientFactory httpClientFactory, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _httpClientFactory = httpClientFactory;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           
            var username = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = username;

            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Author/GetAllAuthor");
            
            if (responsesMessage.IsSuccessStatusCode)
            {
                // Author Count
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AuthorListDto>>(jsondata);
                
                var totalAuthors = values?.Count ?? 0;

                ViewBag.TotalAuthors = totalAuthors; 


                //Book Count
                var responseTotalBookCount = await client.GetAsync("https://localhost:7062/api/Product/ProductList");
                var jsondataTotalBook = await responseTotalBookCount.Content.ReadAsStringAsync();
                var valueTotalBook = JsonConvert.DeserializeObject<List<ProductListDto>>(jsondataTotalBook);
                var totalBook = valueTotalBook?.Count ?? 0;
                ViewBag.TotalBooks = totalBook;

                //Category Count

                var responseMessageCategory = await client.GetAsync("https://localhost:7062/api/Category");
                var jsonDataCategory=await responseMessageCategory.Content.ReadAsStringAsync();
                var valuesCategory = JsonConvert.DeserializeObject<List<CategoryListDto>>(jsonDataCategory);
                ViewBag.Category = valuesCategory.Count();

                //Article Count
                var responseMessageArticle = await client.GetAsync("https://localhost:7062/api/Article/GelAllArticle");
                var jsonDataArticle=await responseMessageArticle.Content.ReadAsStringAsync();
                var valuesArticle=JsonConvert.DeserializeObject<List<ArticleListDto>>(jsonDataArticle);
                ViewBag.Article = valuesArticle.Count();
                return View(values);
            }
           
            
            
            return View();

        }
    }
}

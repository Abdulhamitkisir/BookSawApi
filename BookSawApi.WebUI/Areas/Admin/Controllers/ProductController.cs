using BookSawApi.WebUI.Dtos;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using BookSawApi.WebUI.Dtos.CategoryDtos;
using BookSawApi.WebUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BookSawApi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> BookList()
        {
            var client = _httpClientFactory.CreateClient();
            var responsesMessage = await client.GetAsync("https://localhost:7062/api/Product/ProductList");
            if (responsesMessage.IsSuccessStatusCode)
            {
                var jsondata = await responsesMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ProductListDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateBook()
        {
            var client = _httpClientFactory.CreateClient(); // HTTP istemcisi oluşturuluyor.

            var responseMessageCategory = await client.GetAsync("https://localhost:7062/api/Category"); // Kategori verilerini almak için API'ye istek gönderiyoruz.
            var jsonData = await responseMessageCategory.Content.ReadAsStringAsync(); // API'den gelen kategorileri JSON olarak alıyoruz.
            var values = JsonConvert.DeserializeObject<List<CategoryListDto>>(jsonData); // JSON verisini deseralize ediyoruz.

            List<SelectListItem> categoryList = (from x in values // Kategori verilerinden SelectListItem nesneleri oluşturuyoruz.
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.Categories = categoryList; // Kategorileri ViewBag'e atıyoruz, View'de kullanmak için.

            var responseMessageAuthor = await client.GetAsync("https://localhost:7062/api/Author/GetAllAuthor");
            var jsonDataAuthor = await responseMessageAuthor.Content.ReadAsStringAsync();
            var valuesAuthor = JsonConvert.DeserializeObject<List<AuthorListDto>>(jsonDataAuthor);

            List<SelectListItem> authorList = (from x in valuesAuthor
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName + " " + x.AuthorSurname,
                                                   Value = x.AuthorId.ToString()
                                               }).ToList();

            ViewBag.Authors = authorList;

            return View(); // View'i döndürüyoruz.

        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient(); // HTTP istemcisi oluşturuluyor.
            var jsonData = JsonConvert.SerializeObject(createProductDto); // CreateBookDto nesnesini JSON formatına çeviriyoruz.

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json"); // JSON verisini HTTP isteği olarak gönderiyoruz.
            var responseMessage = await client.PostAsync("https://localhost:7062/api/Product/ProductCreate", stringContent); // API'ye yeni kitap eklemek için POST isteği gönderiyoruz.

            if (responseMessage.IsSuccessStatusCode) // Eğer kitap ekleme başarılı olursa.
            {
                return Redirect("/Admin/Product/BookList"); // Kitap listesine yönlendiriyoruz.
            }

            var errorContent = await responseMessage.Content.ReadAsStringAsync(); // Hata mesajını alıyoruz.
            Console.WriteLine("API Error: " + errorContent); // Hata mesajını konsola yazdırıyoruz.
            TempData["ErrorMessage"] = errorContent; // Hata mesajını TempData'ya koyuyoruz, bunu View'de gösterebiliriz.
            return View(); // Eğer bir hata varsa tekrar aynı sayfayı döndürüyoruz.
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBook(int id)
        {
            var client = _httpClientFactory.CreateClient(); // HTTP istemcisi oluşturuluyor.
            var responseMessageCategory = await client.GetAsync("https://localhost:7062/api/Category"); // Kategori verilerini almak için API'ye istek gönderiyoruz.
            var jsonData = await responseMessageCategory.Content.ReadAsStringAsync(); // API'den gelen kategorileri JSON olarak alıyoruz.
            var values = JsonConvert.DeserializeObject<List<CategoryListDto>>(jsonData); // JSON verisini deseralize ediyoruz.

            List<SelectListItem> categoryList = (from x in values // Kategori verilerinden SelectListItem nesneleri oluşturuyoruz.
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.Categories = categoryList; // Kategorileri ViewBag'e atıyoruz, View'de kullanmak için.

            var responseMessageAuthor = await client.GetAsync("https://localhost:7062/api/Author/GetAllAuthor");
            var jsonDataAuthor = await responseMessageAuthor.Content.ReadAsStringAsync();
            var valuesAuthor = JsonConvert.DeserializeObject<List<AuthorListDto>>(jsonDataAuthor);

            List<SelectListItem> authorList = (from x in valuesAuthor
                                               select new SelectListItem
                                               {
                                                   Text = x.AuthorName + " " + x.AuthorSurname,
                                                   Value = x.AuthorId.ToString()
                                               }).ToList();
            ViewBag.Authors = authorList;

            ////----  Yukarida Kategori ve Yazarlari tekrar getirdim. Update Sayfasinda Tekrar kullanmak icin. Asagida simdi ilgili updatelere devam

            var responseMessage = await client.GetAsync("https://localhost:7062/api/Product/GetProductById?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonDataBook = await responseMessage.Content.ReadAsStringAsync();
                var valuesBook = JsonConvert.DeserializeObject<UpdateProductDto>(jsonDataBook);
                return View(valuesBook);

            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBook(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7062/api/Product/ProductUpdate", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/BookList");
            }
            return View();
        }
        public async Task<IActionResult> DeleteBook(int id)
        { 
            var client= _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7062/api/Product/ProductDelete?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/Admin/Product/BookList");
            }
            return View();
        }

    }
}

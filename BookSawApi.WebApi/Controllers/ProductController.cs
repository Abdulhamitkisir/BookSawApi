using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BookSawApi.WebUI.Dtos.ProductDtos;
using BookSawApi.BusinessLayer.Concrete;


namespace BookSawApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
		public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("ProductList")]
        public IActionResult ProductList()
        {

            return Ok(_productService.TProductList());
        }
        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id) 
        {
            var values=_productService.TGetById(id);
            return Ok(values);
        }
		[HttpGet("GetRandomProduct")]
		public IActionResult GetRandomProduct()
		{
            var value=_productService.TGetRandomProduct();
			return Ok(value);
		}
		[HttpGet("GetProductByCategory")]
		public IActionResult GetProductByCategory()
		{
			var value = _productService.TGetProductWithCategories();
			return Ok(value);
		}
		[HttpGet("LastFourProduct")]
        public IActionResult LastFourProduct()
        {
            return Ok(_productService.TLastFourProduct());
        }
        [HttpPost("ProductCreate")]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TProductCreate(createProductDto);
			return Ok("Succes");
        }
        [HttpPut("ProductUpdate")]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TProductUpdate(updateProductDto);
            return Ok("Update Success");
        }
        [HttpDelete("ProductDelete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Delete Process Success");
        }
        [HttpGet("ProductListByID")]
        public IActionResult GetProductId(int id)
        { 
            var values=_productService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }
        [HttpGet("GetBookWithCategoryId")]
        public IActionResult GetBookWithCategoryId(int id) 
        {
        var values=_productService.TGetBooksByCategoryId(id);
            return Ok(values);
        }

    }
}

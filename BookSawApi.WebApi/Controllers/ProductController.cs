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
        public IActionResult UpdateProduct(int id ,UpdateProductDto updateProductDto)
        {
            _productService.TProductUpdate(id, updateProductDto);
            return Ok("Update Success");
        }
        [HttpDelete("Product Delete")]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Delete Process Success");
        }
        [HttpGet("Product List By ID")]
        public IActionResult GetProductId(int id)
        { 
            var values=_productService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("Product Count")]
        public IActionResult ProductCount()
        {
            return Ok(_productService.TGetProductCount());
        }

    }
}

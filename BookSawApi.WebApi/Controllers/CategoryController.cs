using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult CategoryList() 
        {
            var values=_categoryService.TGetAll();
            return Ok(values);
        }
        [HttpPost("Create")]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        { 
            _categoryService.TCategoryCreate(createCategoryDto);
            return Ok("Insert Process Success");
        }
        [HttpDelete("Delete")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Delete Succes");
        }
        [HttpPut("Update")]
        public IActionResult UpdateCategory(ResultCategoryDto resultCategoryDto)
        {
            _categoryService.TUpdateCategory(resultCategoryDto);
            return Ok("Update Success");
        }

        [HttpGet("GetById")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetById(id);
            return Ok(value);
        }
    }
}

using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthorService _authorService;

		public AuthorController(IAuthorService authorService)
		{
			_authorService = authorService;
		}
		[HttpGet("GetAllAuthor")]
		public IActionResult AuthorList()
		{
			return Ok(_authorService.TAuthorList());
		}
		[HttpPost("CreateAuthor")]
		public IActionResult CreateAuthor(CreateAuthorDto createAuthorDto)
		{
			_authorService.TAuthorCreate(createAuthorDto);
			return Ok("Insert Process Success");
		}
		[HttpPut("UpdateAuthor")]
		public IActionResult UpdateAuthor(int id, UpdateAuthorDto updateAuthorDto)
		{
			_authorService.TAuthorUpdate(id, updateAuthorDto);
			return Ok("Update Process Success");
		}
		[HttpDelete("Delete")]
		public IActionResult DeleteAuthor(int id)
		{
			_authorService.TDelete(id);
			return Ok("Delete Process Success");
		}
		[HttpGet("GetById")]
		public IActionResult AuthorGetById(int id)
		{
			var values = _authorService.TGetById(id);

			return Ok(new
			{
				message = "Succes",
				data = values
			}
			);


		}
	}
}

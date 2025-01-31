using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BookSawApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        [HttpGet("GelAllArticle")]
        public IActionResult ArticleList()
        {
            return Ok(_articleService.TGetAll());
        }
        [HttpGet("GetLastArticle")]
        public IActionResult GetLastArticle() 
        {
            return Ok(_articleService.TLastArticle());
        }
        [HttpPost("CreateArticle")]
        public IActionResult ArticeCreate(Article article)
        {
            var Article = new Article
            {
                ArticleTitle = article.ArticleTitle,
                ArticleDetail = article.ArticleDetail,
                ArticleImageUrl = article.ArticleImageUrl,
            };
            _articleService.TInsert(Article);
            return Ok("Article Save Success");
        }
        [HttpPut("UpdateArticle")]
        public IActionResult ArticleUpdate(Article article)
        {
            _articleService.TUpdate(article);
            return Ok("Article Update Success");
        }
        [HttpDelete("DeleteArticle")]
        public IActionResult ArticleDelete(int id)
        {
            _articleService.TDelete(id);
            return Ok("Delete Success");
        }
        [HttpGet("ArticleGetById")]
        public IActionResult ArticleGetById(int id)
        {
            var values=_articleService.TGetById(id);
            return Ok(values);
        }

    }
}

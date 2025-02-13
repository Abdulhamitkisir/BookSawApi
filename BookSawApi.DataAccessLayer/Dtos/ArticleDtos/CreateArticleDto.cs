using BookSawApi.EntityLayer.Concrete;

namespace BookSawApi.WebUI.Dtos.ArticleDtos
{
    public class CreateArticleDto
    {
        public string ArticleTitle { get; set; }
        public string ArticleDetail { get; set; }
        public string ArticleImageUrl { get; set; }
    }
}

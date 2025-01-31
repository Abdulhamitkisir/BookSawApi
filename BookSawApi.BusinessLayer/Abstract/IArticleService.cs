using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        public List<ArticleListDto> TLastArticle();
    }
}

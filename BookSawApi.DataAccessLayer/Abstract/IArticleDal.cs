using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        public List<ArticleListDto> LastArticle();
    }
}

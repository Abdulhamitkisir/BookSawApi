using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ArticleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void TDelete(int id)
        {
           _articleDal.Delete(id);
        }

        public List<Article> TGetAll()
        {
            return _articleDal.GetAll();
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public void TInsert(Article entitiy)
        {
            _articleDal.Insert(entitiy);
        }

        public List<ArticleListDto> TLastArticle()
        {
            return _articleDal.LastArticle();
        }

        public void TUpdate(Article entitiy)
        {
            _articleDal.Update(entitiy);
        }
    }
}

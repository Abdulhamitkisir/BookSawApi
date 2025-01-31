using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.Context;
using BookSawApi.DataAccessLayer.Repositories;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ArticleDtos;
using BookSawApi.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.EntityFramework
{
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        private readonly BookSawContext context;

        public EfArticleDal(BookSawContext context) : base(context)
        {
            this.context = context;
        }
        public List<ArticleListDto> LastArticle()
        {
            var values = context.Articles
                    .OrderByDescending(p => p.ArticleId)
                    .Take(1)
                    .Select(p => new ArticleListDto    
                        {
                    ArticleId = p.ArticleId,
                    ArticleTitle=p.ArticleTitle,
                    ArticleDetail=p.ArticleDetail,
                    ArticleImageUrl=p.ArticleImageUrl
                        }).ToList();
            return values;
        }
    }
}

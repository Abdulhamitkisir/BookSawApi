using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.Context;
using BookSawApi.DataAccessLayer.Repositories;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using BookSawApi.WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly BookSawContext context;
        public EfCategoryDal(BookSawContext context) : base(context)
        {
            this.context = context;
        }

        public void CategoryCreate(CreateCategoryDto createCategoryDto)
        { 
            var Category=new Category
            { 
                CategoryName=createCategoryDto.CategoryName
            };
            context.Categories.Add(Category);
            context.SaveChanges();
        }

        public void UpdateCategory(ResultCategoryDto resultCategoryDto)
        {
            var CategoryUpdate = context.Categories.FirstOrDefault(x => x.CategoryId == resultCategoryDto.CategoryId);
            if (CategoryUpdate != null) 
            {
                CategoryUpdate.CategoryName = resultCategoryDto.CategoryName;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Author not found");
            }
        }

    }
}

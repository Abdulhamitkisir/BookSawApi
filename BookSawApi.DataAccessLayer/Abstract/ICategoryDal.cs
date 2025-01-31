using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.Abstract
{
    public interface ICategoryDal :IGenericDal<Category>
    {
        public void CategoryCreate(CreateCategoryDto createCategoryDto);
        public void UpdateCategory(ResultCategoryDto resultCategoryDto);
    }
}

using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public void TCategoryCreate(CreateCategoryDto createCategoryDto);
        public void TUpdateCategory(ResultCategoryDto resultCategoryDto);
    }
}

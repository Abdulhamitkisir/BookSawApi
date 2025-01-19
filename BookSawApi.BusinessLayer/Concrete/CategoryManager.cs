using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id)
        {
            _categoryDal.Delete(id);
        }

        public List<Category> TGetAll()
        {
            return _categoryDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void TInsert(Category entitiy)
        {
            _categoryDal.Insert(entitiy);
        }

        public void TUpdate(Category entitiy)
        {
            _categoryDal.Update(entitiy);
        }
    }
}

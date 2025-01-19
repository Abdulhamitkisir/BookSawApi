using BookSawApi.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T entitiy);
        void Update(T entitiy);
        void Delete(int id);
        T GetById(int id);
        List<T> GetAll();
       
    }
}

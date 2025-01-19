using BookSawApi.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.Abstract
{
    public interface ICategoryDal :IGenericDal<Category>
    {
        //Burada Entitye özgü metotdlar yazilir
    }
}

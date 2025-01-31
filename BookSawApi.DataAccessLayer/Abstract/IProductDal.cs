using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.Abstract
{
    public interface IProductDal:IGenericDal<Product>
    {
        int GetProductCount();
        public List<LastFourProductDto> LastFourProduct();
        public List<ProductListDto> ProductList();
        public void ProductCreate(CreateProductDto createProductDto);
        public void ProductUpdate(UpdateProductDto updateProductDto);
        public List<ProductListDto> GetRandomProduct();
        public List<ProductListDto> GetProductWithCategories(int? categoryId = null);
        public List<Product> GetBooksByCategoryId(int id);

    }
}

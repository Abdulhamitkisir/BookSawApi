using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Abstract
{
    public interface IProductService:IGenericService<Product>
    {
        public int TGetProductCount();

        public List<LastFourProductDto> TLastFourProduct();
        public List<ProductListDto> TProductList();
        public void TProductCreate(CreateProductDto createProductDto);
        public void TProductUpdate(UpdateProductDto updateProductDto);
        public List<ProductListDto> TGetRandomProduct();
        public List<ProductListDto> TGetProductWithCategories(int? categoryId = null);
        public List<Product> TGetBooksByCategoryId(int id);

    }
}

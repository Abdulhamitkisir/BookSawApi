using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.EntityFramework;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public void TDelete(int id)
        {
            _productDal.Delete(id);
        }

        public List<Product> TGetAll()
        {
            return _productDal.GetAll();

        }

        public List<Product> TGetBooksByCategoryId(int id)
        {
            return _productDal.GetBooksByCategoryId(id);
        }

        public Product TGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public int TGetProductCount()
        {
            return _productDal.GetProductCount();
        }

		public List<ProductListDto> TGetProductWithCategories(int? categoryId = null)
		{
            return _productDal.GetProductWithCategories(categoryId);
		}

		public List<ProductListDto> TGetRandomProduct()
		{
			return _productDal.GetRandomProduct();
		}

		public void TInsert(Product entitiy)
        {
            _productDal.Insert(entitiy);
        }

		public List<LastFourProductDto> TLastFourProduct()
		{
			return _productDal.LastFourProduct();
		}

		public void TProductCreate(CreateProductDto createProductDto)
		{
			_productDal.ProductCreate(createProductDto);
		}

		public List<ProductListDto> TProductList()
		{
			return _productDal.ProductList();
		}

		public void TProductUpdate( UpdateProductDto updateProductDto)
		{
			_productDal.ProductUpdate(updateProductDto);
		}

		public void TUpdate(Product entitiy)
        {
            _productDal.Update(entitiy);
        }
    }
}

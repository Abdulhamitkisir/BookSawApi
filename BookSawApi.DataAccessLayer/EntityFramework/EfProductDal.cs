using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.Context;
using BookSawApi.DataAccessLayer.Repositories;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.ProductDtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookSawApi.EntityLayer.Concrete;
namespace BookSawApi.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		private readonly BookSawContext context;
		public EfProductDal(BookSawContext context) : base(context)
		{
			this.context = context;
		}

		public int GetProductCount()
		{
			var context = new BookSawContext();
			int value = context.Products.Count();
			return value;
		}
        public List<Product> GetBooksByCategoryId(int id)
        {
            //return context.Books.Include(a => a.Writer).Where(x => x.CategoryId == id).ToList();
			return context.Products.Where(x=> x.CategoryId==id).ToList();
        }

        public List<LastFourProductDto> LastFourProduct()
		{

			// Son 4 ürünü ve ilişkili Author ve Category bilgilerini almak

			var lastFourProducts = context.Products
				.OrderByDescending(p => p.ProductId)  // En son eklenen ürünleri almak için ID'yi azalan sırada sıralıyoruz.
				.Take(4)  // İlk 4 ürünü alıyoruz.
				.Select(p => new LastFourProductDto
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName,
					ProductImageUrl = p.ProductImageUrl,
					ProductDescription = p.ProductDescription,
					ProductStock = p.ProductStock,
					ProductPrice = p.ProductPrice,
					AuthorName = p.Author.AuthorName,
					AuthorSurname = p.Author.AuthorSurname,
					CategoryName = p.Category.CategoryName
				})
				.ToList();  // Sonuçları liste olarak alıyoruz.

			return lastFourProducts;  // DTO listesi olarak döndürüyoruz.
		}
		public List<ProductListDto> ProductList()
		{

			var allProducts = context.Products
												.OrderBy(p => p.ProductId)  // Ürünleri ID'ye göre sıralıyoruz (istenirse başka bir sıralama yapılabilir)
												.Select(p => new ProductListDto  // DTO'yu dönüyoruz
												{
													ProductId = p.ProductId,
													ProductName = p.ProductName,
													ProductImageUrl = p.ProductImageUrl,
													ProductDescription = p.ProductDescription,
													ProductStock = p.ProductStock,
													ProductPrice = p.ProductPrice,
													AuthorName = p.Author.AuthorName,
													AuthorSurname = p.Author.AuthorSurname,
													CategoryName = p.Category.CategoryName
												})
												.ToList();  // Sonuçları liste olarak alıyoruz.

			return allProducts;  // DTO listesi olarak döndürüyoruz.

		}

		public void ProductCreate(CreateProductDto createProductDto)
		{

			var product = new Product
			{
				ProductName = createProductDto.ProductName,
				ProductImageUrl = createProductDto.ProductImageUrl,
				ProductDescription = createProductDto.ProductDescription,
				ProductStock = createProductDto.ProductStock,
				ProductPrice = createProductDto.ProductPrice,
				AuthorId = createProductDto.AuthorId,
				CategoryId = createProductDto.CategoryId,



			};
			context.Products.Add(product);
			context.SaveChanges();
		}
		public void ProductUpdate(UpdateProductDto updateProductDto)
		{

			var updateProduct = context.Products.FirstOrDefault(p => p.ProductId ==updateProductDto.ProductId);


			if (updateProduct != null)
			{
				// Ürün bulunduysa, DTO'dan gelen yeni verilerle güncelliyoruz
				updateProduct.ProductName = updateProductDto.ProductName;
				updateProduct.ProductImageUrl = updateProductDto.ProductImageUrl;
				updateProduct.ProductDescription = updateProductDto.ProductDescription;
				updateProduct.ProductStock = updateProductDto.ProductStock;
				updateProduct.ProductPrice = updateProductDto.ProductPrice;
				updateProduct.AuthorId = updateProductDto.AuthorId;
				updateProduct.CategoryId = updateProductDto.CategoryId;

				// Değişiklikleri kaydediyoruz
				context.SaveChanges();
			}
			else
			{
				// Ürün bulunamazsa uygun bir işlem yapılabilir
				throw new Exception("Product not found");
			}
		}
		public List<ProductListDto> GetRandomProduct()
		{
			var randomProduct = context.Products
				.OrderBy(p => Guid.NewGuid()) //productan benzersiz guid olusuurr
				.Take(1)
				.Select(p => new ProductListDto
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName,
					ProductImageUrl = p.ProductImageUrl,
					ProductDescription = p.ProductDescription,
					ProductStock = p.ProductStock,
					ProductPrice = p.ProductPrice,
					AuthorName = p.Author.AuthorName,
					AuthorSurname = p.Author.AuthorSurname,
					CategoryName = p.Category.CategoryName
				})
				.ToList();
			return randomProduct;
		}

		public List<ProductListDto> GetProductWithCategories(int? categoryId = null)
		{
			// Eğer categoryId null ise, tüm kategorilerden ürünleri getirir.
			var productsQuery = context.Products.AsQueryable();
			if (categoryId.HasValue)
			{
				// Belirli bir kategori için filtre uygula
				productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
			}
			// Ürünleri kategorilere göre listele
			var products = productsQuery
				.OrderBy(p => Guid.NewGuid()) // Rastgele sıralama
				.Select(p => new ProductListDto
				{
					ProductId = p.ProductId,
					ProductName = p.ProductName,
					ProductImageUrl = p.ProductImageUrl,
					ProductDescription = p.ProductDescription,
					ProductStock = p.ProductStock,
					ProductPrice = p.ProductPrice,
					AuthorName = p.Author.AuthorName,
					AuthorSurname = p.Author.AuthorSurname,
					CategoryName = p.Category.CategoryName
				})
				.ToList();

			return products;
		}
	}
}

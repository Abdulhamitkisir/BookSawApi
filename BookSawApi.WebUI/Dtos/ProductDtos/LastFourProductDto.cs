using BookSawApi.EntityLayer.Concrete;

namespace BookSawApi.WebUI.Dtos.ProductDtos
{
	public class LastFourProductDto
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductImageUrl { get; set; }
		public string ProductDescription { get; set; }
		public int ProductStock { get; set; }
		public decimal ProductPrice { get; set; }
		public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public string CategoryName { get; set; }

	}
}

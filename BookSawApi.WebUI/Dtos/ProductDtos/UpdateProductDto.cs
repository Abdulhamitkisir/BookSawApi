﻿namespace BookSawApi.WebUI.Dtos.ProductDtos
{
	public class UpdateProductDto
	{
        public int ProductId { get; set; }
        public string ProductName { get; set; }
		public string ProductImageUrl { get; set; }
		public string ProductDescription { get; set; }
		public int ProductStock { get; set; }
		public decimal ProductPrice { get; set; }
		public int AuthorId { get; set; }
		public int CategoryId { get; set; }
	}
}

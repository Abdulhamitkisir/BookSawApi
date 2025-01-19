using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public int AuthorId { get;  set; }
        public Author Author { get; set; }
        public int CategoryId { get;  set; }
        public Category Category { get; set; }
	
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.EntityLayer.Concrete
{
    public class Author
    {
        public  int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorUmageUrl { get; set; }
        public List<Product> Products { get; set; }
    }
}

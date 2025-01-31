using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.EntityLayer.Concrete
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleDetail { get; set; }
        public string ArticleImageUrl { get; set; }
    }
}

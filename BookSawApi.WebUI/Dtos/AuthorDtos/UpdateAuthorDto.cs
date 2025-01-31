using BookSawApi.EntityLayer.Concrete;

namespace BookSawApi.WebUI.Dtos.AuthorDtos
{
	public class UpdateAuthorDto
	{
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
		public string AuthorSurname { get; set; }
		public string AuthorDescription { get; set; }
		public string AuthorUmageUrl { get; set; }
       
    }
}

using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.Context;
using BookSawApi.DataAccessLayer.Repositories;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.EntityFramework
{
    
    public class EfAuthorDal : GenericRepository<Author>, IAuthorDal
    {
		private readonly BookSawContext context;

		public EfAuthorDal(BookSawContext context) : base(context)
        {
            this.context = context;
		}

        public List<AuthorListDto> AuthorList()
        {
           // var context = new BookSawContext();
            var GetAllAuthor= context.Authors
                                            .OrderBy(x=> x.AuthorId)
                                            .Select(x=> new AuthorListDto
                                            { AuthorId=x.AuthorId,
                                              AuthorName=x.AuthorName,
                                              AuthorSurname=x.AuthorSurname,
                                              AuthorDescription=x.AuthorDescription,
                                              AuthorUmageUrl=x.AuthorUmageUrl
                                            }).ToList();
            return GetAllAuthor;
        }
        
		

		public void TAuthorCreate(CreateAuthorDto createAuthorDto)
		{
			var Author = new Author
			{
				AuthorName = createAuthorDto.AuthorName,
				AuthorSurname = createAuthorDto.AuthorSurname,
				AuthorDescription = createAuthorDto.AuthorDescription,
				AuthorUmageUrl = createAuthorDto.AuthorUmageUrl
			};
			context.Authors.Add(Author);
			context.SaveChanges();
		}

		public void TAuthorUpdate(int id, UpdateAuthorDto updateAuthorDto)
		{
			var AuthorUpdate = context.Authors.FirstOrDefault(x => x.AuthorId == id);
			if (AuthorUpdate != null)
			{
				AuthorUpdate.AuthorName = updateAuthorDto.AuthorName;
				AuthorUpdate.AuthorSurname = updateAuthorDto.AuthorSurname;
				AuthorUpdate.AuthorDescription = updateAuthorDto.AuthorDescription;
				AuthorUpdate.AuthorUmageUrl = updateAuthorDto.AuthorUmageUrl;
				context.SaveChanges();
			}
			else
			{
				throw new Exception("Author not found");
			}
		}
	}
}

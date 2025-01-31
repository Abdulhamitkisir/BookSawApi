using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.DataAccessLayer.Abstract
{
    public interface IAuthorDal:IGenericDal<Author>
    {
		public List<AuthorListDto> AuthorList();
		public void AuthorCreate(CreateAuthorDto createAuthorDto);
		public void AuthorUpdate(UpdateAuthorDto updateAuthorDto);
	}
}

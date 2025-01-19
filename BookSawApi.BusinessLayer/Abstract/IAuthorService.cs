using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Abstract
{
    public interface IAuthorService:IGenericService<Author>
    {
		public List<AuthorListDto> TAuthorList();
		public void TAuthorCreate(CreateAuthorDto createAuthorDto);
		public void TAuthorUpdate(int id, UpdateAuthorDto updateAuthorDto);
	}
}

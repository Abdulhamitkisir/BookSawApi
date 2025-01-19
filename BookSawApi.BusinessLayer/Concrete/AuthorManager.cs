using BookSawApi.BusinessLayer.Abstract;
using BookSawApi.DataAccessLayer.Abstract;
using BookSawApi.DataAccessLayer.EntityFramework;
using BookSawApi.EntityLayer.Concrete;
using BookSawApi.WebUI.Dtos.AuthorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSawApi.BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;

        public AuthorManager(IAuthorDal authorDal)
        {
            _authorDal = authorDal;
        }

        public void TInsert(Author entitiy)
        {
            _authorDal.Insert(entitiy);
        }

        public void TUpdate(Author entitiy)
        {
            _authorDal.Update(entitiy);
        }

        public void TDelete(int id)
        {
            _authorDal.Delete(id);
        }

        public Author TGetById(int id)
        {
            return _authorDal.GetById(id);
        }

        public List<Author> TGetAll()
        {
            return _authorDal.GetAll();
        }

		public List<AuthorListDto> TAuthorList()
		{
            return _authorDal.AuthorList();
		}

		public void TAuthorCreate(CreateAuthorDto createAuthorDto)
		{
			 _authorDal.TAuthorCreate(createAuthorDto);
		}

		public void TAuthorUpdate(int id, UpdateAuthorDto updateAuthorDto)
		{
			_authorDal.TAuthorUpdate(id, updateAuthorDto);
		}
	}
}

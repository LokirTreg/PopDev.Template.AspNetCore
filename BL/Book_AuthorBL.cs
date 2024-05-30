using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using BookAuthor = Entities.BookAuthor;

namespace BL
{
	public class Book_AuthorBL
	{
		public async Task<int> AddOrUpdateAsync(BookAuthor entity)
		{
			entity.Id = await new Book_AuthorDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new Book_AuthorDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(Book_AuthorSearchParams searchParams)
		{
			return new Book_AuthorDal().ExistsAsync(searchParams);
		}

		public Task<BookAuthor> GetAsync(int id)
		{
			return new Book_AuthorDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new Book_AuthorDal().DeleteAsync(id);
		}

		public Task<SearchResult<BookAuthor>> GetAsync(Book_AuthorSearchParams searchParams)
		{
			return new Book_AuthorDal().GetAsync(searchParams);
		}
	}
}


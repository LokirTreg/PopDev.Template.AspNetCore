using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Book = Entities.Book;

namespace BL
{
	public class BookBL
	{
		public async Task<int> AddOrUpdateAsync(Book entity)
		{
			entity.Id = await new BookDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new BookDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(BookSearchParams searchParams)
		{
			return new BookDal().ExistsAsync(searchParams);
		}

		public Task<Book> GetAsync(int id)
		{
			return new BookDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new BookDal().DeleteAsync(id);
		}

		public Task<SearchResult<Book>> GetAsync(BookSearchParams searchParams)
		{
			return new BookDal().GetAsync(searchParams);
		}
	}
}


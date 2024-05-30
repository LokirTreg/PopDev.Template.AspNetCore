using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using BookGenre = Entities.BookGenre;

namespace BL
{
	public class Book_GenreBL
	{
		public async Task<int> AddOrUpdateAsync(BookGenre entity)
		{
			entity.Id = await new Book_GenreDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new Book_GenreDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(Book_GenreSearchParams searchParams)
		{
			return new Book_GenreDal().ExistsAsync(searchParams);
		}

		public Task<BookGenre> GetAsync(int id)
		{
			return new Book_GenreDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new Book_GenreDal().DeleteAsync(id);
		}

		public Task<SearchResult<BookGenre>> GetAsync(Book_GenreSearchParams searchParams)
		{
			return new Book_GenreDal().GetAsync(searchParams);
		}
	}
}


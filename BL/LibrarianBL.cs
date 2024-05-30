using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Librarian = Entities.Librarian;

namespace BL
{
	public class LibrarianBL
	{
		public async Task<int> AddOrUpdateAsync(Librarian entity)
		{
			entity.Id = await new LibrarianDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new LibrarianDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(LibrarianSearchParams searchParams)
		{
			return new LibrarianDal().ExistsAsync(searchParams);
		}

		public Task<Librarian> GetAsync(int id)
		{
			return new LibrarianDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new LibrarianDal().DeleteAsync(id);
		}

		public Task<SearchResult<Librarian>> GetAsync(LibrarianSearchParams searchParams)
		{
			return new LibrarianDal().GetAsync(searchParams);
		}
	}
}


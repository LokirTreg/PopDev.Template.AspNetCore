using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using IssuedBook = Entities.IssuedBook;

namespace BL
{
	public class Issued_bookBL
	{
		public async Task<int> AddOrUpdateAsync(IssuedBook entity)
		{
			entity.Id = await new Issued_bookDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new Issued_bookDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(Issued_bookSearchParams searchParams)
		{
			return new Issued_bookDal().ExistsAsync(searchParams);
		}

		public Task<IssuedBook> GetAsync(int id)
		{
			return new Issued_bookDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new Issued_bookDal().DeleteAsync(id);
		}

		public Task<SearchResult<IssuedBook>> GetAsync(Issued_bookSearchParams searchParams)
		{
			return new Issued_bookDal().GetAsync(searchParams);
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using CopyOfBook = Entities.CopyOfBook;

namespace BL
{
	public class Copy_of_bookBL
	{
		public async Task<int> AddOrUpdateAsync(CopyOfBook entity)
		{
			entity.Id = await new Copy_of_bookDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new Copy_of_bookDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(Copy_of_bookSearchParams searchParams)
		{
			return new Copy_of_bookDal().ExistsAsync(searchParams);
		}

		public Task<CopyOfBook> GetAsync(int id)
		{
			return new Copy_of_bookDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new Copy_of_bookDal().DeleteAsync(id);
		}

		public Task<SearchResult<CopyOfBook>> GetAsync(Copy_of_bookSearchParams searchParams)
		{
			return new Copy_of_bookDal().GetAsync(searchParams);
		}
	}
}


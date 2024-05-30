using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Reader = Entities.Reader;

namespace BL
{
	public class ReaderBL
	{
		public async Task<int> AddOrUpdateAsync(Reader entity)
		{
			entity.Id = await new ReaderDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new ReaderDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(ReaderSearchParams searchParams)
		{
			return new ReaderDal().ExistsAsync(searchParams);
		}

		public Task<Reader> GetAsync(int id)
		{
			return new ReaderDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new ReaderDal().DeleteAsync(id);
		}

		public Task<SearchResult<Reader>> GetAsync(ReaderSearchParams searchParams)
		{
			return new ReaderDal().GetAsync(searchParams);
		}
	}
}


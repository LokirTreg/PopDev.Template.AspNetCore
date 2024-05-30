using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Genre = Entities.Genre;

namespace BL
{
	public class GenreBL
	{
		public async Task<int> AddOrUpdateAsync(Genre entity)
		{
			entity.Id = await new GenreDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new GenreDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(GenreSearchParams searchParams)
		{
			return new GenreDal().ExistsAsync(searchParams);
		}

		public Task<Genre> GetAsync(int id)
		{
			return new GenreDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new GenreDal().DeleteAsync(id);
		}

		public Task<SearchResult<Genre>> GetAsync(GenreSearchParams searchParams)
		{
			return new GenreDal().GetAsync(searchParams);
		}
	}
}


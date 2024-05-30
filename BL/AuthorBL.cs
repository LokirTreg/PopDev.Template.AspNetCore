using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Author = Entities.Author;

namespace BL
{
	public class AuthorBL
	{
		public async Task<int> AddOrUpdateAsync(Author entity)
		{
			entity.Id = await new AuthorDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new AuthorDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(AuthorSearchParams searchParams)
		{
			return new AuthorDal().ExistsAsync(searchParams);
		}

		public Task<Author> GetAsync(int id)
		{
			return new AuthorDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new AuthorDal().DeleteAsync(id);
		}

		public Task<SearchResult<Author>> GetAsync(AuthorSearchParams searchParams)
		{
			return new AuthorDal().GetAsync(searchParams);
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Publisher = Entities.Publisher;

namespace BL
{
	public class PublisherBL
	{
		public async Task<int> AddOrUpdateAsync(Publisher entity)
		{
			entity.Id = await new PublisherDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new PublisherDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(PublisherSearchParams searchParams)
		{
			return new PublisherDal().ExistsAsync(searchParams);
		}

		public Task<Publisher> GetAsync(int id)
		{
			return new PublisherDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new PublisherDal().DeleteAsync(id);
		}

		public Task<SearchResult<Publisher>> GetAsync(PublisherSearchParams searchParams)
		{
			return new PublisherDal().GetAsync(searchParams);
		}
	}
}


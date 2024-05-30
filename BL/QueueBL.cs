using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Queue = Entities.Queue;

namespace BL
{
	public class QueueBL
	{
		public async Task<int> AddOrUpdateAsync(Queue entity)
		{
			entity.Id = await new QueueDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new QueueDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(QueueSearchParams searchParams)
		{
			return new QueueDal().ExistsAsync(searchParams);
		}

		public Task<Queue> GetAsync(int id)
		{
			return new QueueDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new QueueDal().DeleteAsync(id);
		}

		public Task<SearchResult<Queue>> GetAsync(QueueSearchParams searchParams)
		{
			return new QueueDal().GetAsync(searchParams);
		}
	}
}


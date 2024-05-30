using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Penalty = Entities.Penalty;

namespace BL
{
	public class PenaltyBL
	{
		public async Task<int> AddOrUpdateAsync(Penalty entity)
		{
			entity.Id = await new PenaltyDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new PenaltyDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(PenaltySearchParams searchParams)
		{
			return new PenaltyDal().ExistsAsync(searchParams);
		}

		public Task<Penalty> GetAsync(int id)
		{
			return new PenaltyDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new PenaltyDal().DeleteAsync(id);
		}

		public Task<SearchResult<Penalty>> GetAsync(PenaltySearchParams searchParams)
		{
			return new PenaltyDal().GetAsync(searchParams);
		}
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using PenaltyDebtor = Entities.PenaltyDebtor;

namespace BL
{
	public class Penalty_DebtorBL
	{
		public async Task<int> AddOrUpdateAsync(PenaltyDebtor entity)
		{
			entity.Id = await new Penalty_DebtorDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new Penalty_DebtorDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(Penalty_DebtorSearchParams searchParams)
		{
			return new Penalty_DebtorDal().ExistsAsync(searchParams);
		}

		public Task<PenaltyDebtor> GetAsync(int id)
		{
			return new Penalty_DebtorDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new Penalty_DebtorDal().DeleteAsync(id);
		}

		public Task<SearchResult<PenaltyDebtor>> GetAsync(Penalty_DebtorSearchParams searchParams)
		{
			return new Penalty_DebtorDal().GetAsync(searchParams);
		}
	}
}


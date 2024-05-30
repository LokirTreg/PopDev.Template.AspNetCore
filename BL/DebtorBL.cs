using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Common.Enums;
using Common.Search;
using Debtor = Entities.Debtor;

namespace BL
{
	public class DebtorBL
	{
		public async Task<int> AddOrUpdateAsync(Debtor entity)
		{
			entity.Id = await new DebtorDal().AddOrUpdateAsync(entity);
			return entity.Id;
		}

		public Task<bool> ExistsAsync(int id)
		{
			return new DebtorDal().ExistsAsync(id);
		}

		public Task<bool> ExistsAsync(DebtorSearchParams searchParams)
		{
			return new DebtorDal().ExistsAsync(searchParams);
		}

		public Task<Debtor> GetAsync(int id)
		{
			return new DebtorDal().GetAsync(id);
		}

		public Task<bool> DeleteAsync(int id)
		{
			return new DebtorDal().DeleteAsync(id);
		}

		public Task<SearchResult<Debtor>> GetAsync(DebtorSearchParams searchParams)
		{
			return new DebtorDal().GetAsync(searchParams);
		}
	}
}


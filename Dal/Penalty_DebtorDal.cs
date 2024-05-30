using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class Penalty_DebtorDal : BaseDal<DefaultDbContext, PenaltyDebtor, Entities.PenaltyDebtor, int, Penalty_DebtorSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public Penalty_DebtorDal()
		{
		}

		protected internal Penalty_DebtorDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.PenaltyDebtor entity, PenaltyDebtor dbObject, bool exists)
		{
			dbObject.IdPenalty = entity.IdPenalty;
			dbObject.IdDebtor = entity.IdDebtor;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<PenaltyDebtor>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<PenaltyDebtor> dbObjects, Penalty_DebtorSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.PenaltyDebtor>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<PenaltyDebtor> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<PenaltyDebtor, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.PenaltyDebtor, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.PenaltyDebtor ConvertDbObjectToEntity(PenaltyDebtor dbObject)
		{
			return dbObject == null ? null : new Entities.PenaltyDebtor(dbObject.Id, dbObject.IdPenalty,
				dbObject.IdDebtor);
		}
	}
}

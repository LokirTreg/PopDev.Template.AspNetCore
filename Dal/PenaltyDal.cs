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
	public class PenaltyDal : BaseDal<DefaultDbContext, Penalty, Entities.Penalty, int, PenaltySearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public PenaltyDal()
		{
		}

		protected internal PenaltyDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Penalty entity, Penalty dbObject, bool exists)
		{
			dbObject.SizeOfPenalty = entity.SizeOfPenalty;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Penalty>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Penalty> dbObjects, PenaltySearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Penalty>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Penalty> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Penalty, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Penalty, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Penalty ConvertDbObjectToEntity(Penalty dbObject)
		{
			return dbObject == null ? null : new Entities.Penalty(dbObject.Id, dbObject.SizeOfPenalty);
		}
	}
}

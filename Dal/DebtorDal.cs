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
	public class DebtorDal : BaseDal<DefaultDbContext, Debtor, Entities.Debtor, int, DebtorSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public DebtorDal()
		{
		}

		protected internal DebtorDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Debtor entity, Debtor dbObject, bool exists)
		{
			dbObject.IdIssuedBook = entity.IdIssuedBook;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Debtor>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Debtor> dbObjects, DebtorSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Debtor>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Debtor> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Debtor, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Debtor, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Debtor ConvertDbObjectToEntity(Debtor dbObject)
		{
			return dbObject == null ? null : new Entities.Debtor(dbObject.Id, dbObject.IdIssuedBook);
		}
	}
}

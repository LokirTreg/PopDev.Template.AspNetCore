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
	public class Copy_of_bookDal : BaseDal<DefaultDbContext, CopyOfBook, Entities.CopyOfBook, int, Copy_of_bookSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public Copy_of_bookDal()
		{
		}

		protected internal Copy_of_bookDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.CopyOfBook entity, CopyOfBook dbObject, bool exists)
		{
			dbObject.IdBook = entity.IdBook;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<CopyOfBook>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<CopyOfBook> dbObjects, Copy_of_bookSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.CopyOfBook>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<CopyOfBook> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<CopyOfBook, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.CopyOfBook, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.CopyOfBook ConvertDbObjectToEntity(CopyOfBook dbObject)
		{
			return dbObject == null ? null : new Entities.CopyOfBook(dbObject.Id, dbObject.IdBook);
		}
	}
}

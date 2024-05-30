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
	public class Issued_bookDal : BaseDal<DefaultDbContext, IssuedBook, Entities.IssuedBook, int, Issued_bookSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public Issued_bookDal()
		{
		}

		protected internal Issued_bookDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.IssuedBook entity, IssuedBook dbObject, bool exists)
		{
			dbObject.DateOfIssue = entity.DateOfIssue;
			dbObject.DateOfPlannedDelivery = entity.DateOfPlannedDelivery;
			dbObject.IdReader = entity.IdReader;
			dbObject.IdLibrarian = entity.IdLibrarian;
			dbObject.IdCopyOfBook = entity.IdCopyOfBook;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<IssuedBook>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<IssuedBook> dbObjects, Issued_bookSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.IssuedBook>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<IssuedBook> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<IssuedBook, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.IssuedBook, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.IssuedBook ConvertDbObjectToEntity(IssuedBook dbObject)
		{
			return dbObject == null ? null : new Entities.IssuedBook(dbObject.Id, dbObject.DateOfIssue,
				dbObject.DateOfPlannedDelivery, dbObject.IdReader, dbObject.IdLibrarian, dbObject.IdCopyOfBook);
		}
	}
}

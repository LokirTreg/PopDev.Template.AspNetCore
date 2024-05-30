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
	public class BookDal : BaseDal<DefaultDbContext, Book, Entities.Book, int, BookSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public BookDal()
		{
		}

		protected internal BookDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Book entity, Book dbObject, bool exists)
		{
			dbObject.Title = entity.Title;
			dbObject.YearOfPublish = entity.YearOfPublish;
			dbObject.Circulation = entity.Circulation;
			dbObject.IdPublisher = entity.IdPublisher;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Book>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Book> dbObjects, BookSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Book>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Book> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Book, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Book, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Book ConvertDbObjectToEntity(Book dbObject)
		{
			return dbObject == null ? null : new Entities.Book(dbObject.Id, dbObject.Title, dbObject.YearOfPublish,
				dbObject.Circulation, dbObject.IdPublisher);
		}
	}
}

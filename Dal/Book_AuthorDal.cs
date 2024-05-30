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
	public class Book_AuthorDal : BaseDal<DefaultDbContext, BookAuthor, Entities.BookAuthor, int, Book_AuthorSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public Book_AuthorDal()
		{
		}

		protected internal Book_AuthorDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.BookAuthor entity, BookAuthor dbObject, bool exists)
		{
			dbObject.IdAuthor = entity.IdAuthor;
			dbObject.IdBook = entity.IdBook;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<BookAuthor>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<BookAuthor> dbObjects, Book_AuthorSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.BookAuthor>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<BookAuthor> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<BookAuthor, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.BookAuthor, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.BookAuthor ConvertDbObjectToEntity(BookAuthor dbObject)
		{
			return dbObject == null ? null : new Entities.BookAuthor(dbObject.Id, dbObject.IdAuthor, dbObject.IdBook);
		}
	}
}

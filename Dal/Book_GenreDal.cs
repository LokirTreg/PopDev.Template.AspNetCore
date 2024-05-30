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
	public class Book_GenreDal : BaseDal<DefaultDbContext, BookGenre, Entities.BookGenre, int, Book_GenreSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public Book_GenreDal()
		{
		}

		protected internal Book_GenreDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.BookGenre entity, BookGenre dbObject, bool exists)
		{
			dbObject.IdGenre = entity.IdGenre;
			dbObject.IdBook = entity.IdBook;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<BookGenre>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<BookGenre> dbObjects, Book_GenreSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.BookGenre>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<BookGenre> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<BookGenre, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.BookGenre, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.BookGenre ConvertDbObjectToEntity(BookGenre dbObject)
		{
			return dbObject == null ? null : new Entities.BookGenre(dbObject.Id, dbObject.IdGenre, dbObject.IdBook);
		}
	}
}

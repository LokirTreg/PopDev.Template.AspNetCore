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
	public class LibrarianDal : BaseDal<DefaultDbContext, Librarian, Entities.Librarian, int, LibrarianSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public LibrarianDal()
		{
		}

		protected internal LibrarianDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Librarian entity, Librarian dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Librarian>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Librarian> dbObjects, LibrarianSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Librarian>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Librarian> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Librarian, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Librarian, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Librarian ConvertDbObjectToEntity(Librarian dbObject)
		{
			return dbObject == null ? null : new Entities.Librarian(dbObject.Id, dbObject.Name);
		}
	}
}

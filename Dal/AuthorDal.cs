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
	public class AuthorDal : BaseDal<DefaultDbContext, Author, Entities.Author, int, AuthorSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public AuthorDal()
		{
		}

		protected internal AuthorDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Author entity, Author dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Author>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Author> dbObjects, AuthorSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Author>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Author> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Author, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Author, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Author ConvertDbObjectToEntity(Author dbObject)
		{
			return dbObject == null ? null : new Entities.Author(dbObject.Id, dbObject.Name);
		}
	}
}

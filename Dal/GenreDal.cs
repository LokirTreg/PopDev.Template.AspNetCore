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
	public class GenreDal : BaseDal<DefaultDbContext, Genre, Entities.Genre, int, GenreSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public GenreDal()
		{
		}

		protected internal GenreDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Genre entity, Genre dbObject, bool exists)
		{
			dbObject.Name = entity.Name;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Genre>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Genre> dbObjects, GenreSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Genre>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Genre> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Genre, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Genre, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Genre ConvertDbObjectToEntity(Genre dbObject)
		{
			return dbObject == null ? null : new Entities.Genre(dbObject.Id, dbObject.Name);
		}
	}
}

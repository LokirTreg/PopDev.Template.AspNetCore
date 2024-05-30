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
	public class PublisherDal : BaseDal<DefaultDbContext, Publisher, Entities.Publisher, int, PublisherSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public PublisherDal()
		{
		}

		protected internal PublisherDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Publisher entity, Publisher dbObject, bool exists)
		{
			dbObject.Title = entity.Title;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Publisher>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Publisher> dbObjects, PublisherSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Publisher>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Publisher> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Publisher, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Publisher, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Publisher ConvertDbObjectToEntity(Publisher dbObject)
		{
			return dbObject == null ? null : new Entities.Publisher(dbObject.Id, dbObject.Title);
		}
	}
}

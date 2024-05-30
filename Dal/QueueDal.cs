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
	public class QueueDal : BaseDal<DefaultDbContext, Queue, Entities.Queue, int, QueueSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public QueueDal()
		{
		}

		protected internal QueueDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.Queue entity, Queue dbObject, bool exists)
		{
			dbObject.NumberInQueue = entity.NumberInQueue;
			dbObject.IdReader = entity.IdReader;
			dbObject.IdBook = entity.IdBook;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<Queue>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<Queue> dbObjects, QueueSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.Queue>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<Queue> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<Queue, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.Queue, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.Queue ConvertDbObjectToEntity(Queue dbObject)
		{
			return dbObject == null ? null : new Entities.Queue(dbObject.Id, dbObject.NumberInQueue, dbObject.IdReader,
				dbObject.IdBook);
		}
	}
}

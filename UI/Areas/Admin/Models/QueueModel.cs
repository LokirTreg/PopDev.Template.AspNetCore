using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class QueueModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id записи в очереди")]
		public int Id { get; set; }

		[Display(Name = "Номер в очереди")]
		public int? NumberInQueue { get; set; }

		[Display(Name = "Id Читателя")]
		public int? IdReader { get; set; }

		[Display(Name = "Id Книги")]
		public int? IdBook { get; set; }

		public static QueueModel FromEntity(Queue obj)
		{
			return obj == null ? null : new QueueModel
			{
				Id = obj.Id,
				NumberInQueue = obj.NumberInQueue,
				IdReader = obj.IdReader,
				IdBook = obj.IdBook,
			};
		}

		public static Queue ToEntity(QueueModel obj)
		{
			return obj == null ? null : new Queue(obj.Id, obj.NumberInQueue, obj.IdReader, obj.IdBook);
		}

		public static List<QueueModel> FromEntitiesList(IEnumerable<Queue> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Queue> ToEntitiesList(IEnumerable<QueueModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

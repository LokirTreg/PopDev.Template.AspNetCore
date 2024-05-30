using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class CopyOfBookModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Инвентарный номер")]
		public int Id { get; set; }

		[Display(Name = "Id Книги")]
		public int? IdBook { get; set; }

		public static CopyOfBookModel FromEntity(CopyOfBook obj)
		{
			return obj == null ? null : new CopyOfBookModel
			{
				Id = obj.Id,
				IdBook = obj.IdBook,
			};
		}

		public static CopyOfBook ToEntity(CopyOfBookModel obj)
		{
			return obj == null ? null : new CopyOfBook(obj.Id, obj.IdBook);
		}

		public static List<CopyOfBookModel> FromEntitiesList(IEnumerable<CopyOfBook> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<CopyOfBook> ToEntitiesList(IEnumerable<CopyOfBookModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class IssuedBookModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Выданной книги")]
		public int Id { get; set; }

		[Display(Name = "Дата выдачи")]
		public DateTime? DateOfIssue { get; set; }

		[Display(Name = "Дата планируемой сдачи")]
		public DateTime? DateOfPlannedDelivery { get; set; }

		[Display(Name = "Id Читателя")]
		public int? IdReader { get; set; }

		[Display(Name = "Id Библиеотекаря")]
		public int? IdLibrarian { get; set; }

		[Display(Name = "Инвентарный номер")]
		public int? IdCopyOfBook { get; set; }

		public static IssuedBookModel FromEntity(IssuedBook obj)
		{
			return obj == null ? null : new IssuedBookModel
			{
				Id = obj.Id,
				DateOfIssue = obj.DateOfIssue,
				DateOfPlannedDelivery = obj.DateOfPlannedDelivery,
				IdReader = obj.IdReader,
				IdLibrarian = obj.IdLibrarian,
				IdCopyOfBook = obj.IdCopyOfBook,
			};
		}

		public static IssuedBook ToEntity(IssuedBookModel obj)
		{
			return obj == null ? null : new IssuedBook(obj.Id, obj.DateOfIssue, obj.DateOfPlannedDelivery,
				obj.IdReader, obj.IdLibrarian, obj.IdCopyOfBook);
		}

		public static List<IssuedBookModel> FromEntitiesList(IEnumerable<IssuedBook> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<IssuedBook> ToEntitiesList(IEnumerable<IssuedBookModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

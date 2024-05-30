using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class DebtorModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Должника")]
		public int Id { get; set; }

		[Display(Name = "Id Выданной книги")]
		public int? IdIssuedBook { get; set; }

		public static DebtorModel FromEntity(Debtor obj)
		{
			return obj == null ? null : new DebtorModel
			{
				Id = obj.Id,
				IdIssuedBook = obj.IdIssuedBook,
			};
		}

		public static Debtor ToEntity(DebtorModel obj)
		{
			return obj == null ? null : new Debtor(obj.Id, obj.IdIssuedBook);
		}

		public static List<DebtorModel> FromEntitiesList(IEnumerable<Debtor> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Debtor> ToEntitiesList(IEnumerable<DebtorModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

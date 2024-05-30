using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class PenaltyDebtorModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Id Долга")]
		public int? IdPenalty { get; set; }

		[Display(Name = "Id Должника")]
		public int? IdDebtor { get; set; }

		public static PenaltyDebtorModel FromEntity(PenaltyDebtor obj)
		{
			return obj == null ? null : new PenaltyDebtorModel
			{
				Id = obj.Id,
				IdPenalty = obj.IdPenalty,
				IdDebtor = obj.IdDebtor,
			};
		}

		public static PenaltyDebtor ToEntity(PenaltyDebtorModel obj)
		{
			return obj == null ? null : new PenaltyDebtor(obj.Id, obj.IdPenalty, obj.IdDebtor);
		}

		public static List<PenaltyDebtorModel> FromEntitiesList(IEnumerable<PenaltyDebtor> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<PenaltyDebtor> ToEntitiesList(IEnumerable<PenaltyDebtorModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class PenaltyModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "SizeOfPenalty")]
		public int? SizeOfPenalty { get; set; }

		public static PenaltyModel FromEntity(Penalty obj)
		{
			return obj == null ? null : new PenaltyModel
			{
				Id = obj.Id,
				SizeOfPenalty = obj.SizeOfPenalty,
			};
		}

		public static Penalty ToEntity(PenaltyModel obj)
		{
			return obj == null ? null : new Penalty(obj.Id, obj.SizeOfPenalty);
		}

		public static List<PenaltyModel> FromEntitiesList(IEnumerable<Penalty> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Penalty> ToEntitiesList(IEnumerable<PenaltyModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

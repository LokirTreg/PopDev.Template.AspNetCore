using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class ReaderModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Читателя")]
		public int Id { get; set; }

		[Display(Name = "Имя Читателя")]
		public string Name { get; set; }

		public static ReaderModel FromEntity(Reader obj)
		{
			return obj == null ? null : new ReaderModel
			{
				Id = obj.Id,
				Name = obj.Name,
			};
		}

		public static Reader ToEntity(ReaderModel obj)
		{
			return obj == null ? null : new Reader(obj.Id, obj.Name);
		}

		public static List<ReaderModel> FromEntitiesList(IEnumerable<Reader> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Reader> ToEntitiesList(IEnumerable<ReaderModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

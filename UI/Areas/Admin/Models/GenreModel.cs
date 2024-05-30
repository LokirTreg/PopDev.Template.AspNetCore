using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class GenreModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Жанра")]
		public int Id { get; set; }

		[Display(Name = "Название")]
		public string Name { get; set; }

		public static GenreModel FromEntity(Genre obj)
		{
			return obj == null ? null : new GenreModel
			{
				Id = obj.Id,
				Name = obj.Name,
			};
		}

		public static Genre ToEntity(GenreModel obj)
		{
			return obj == null ? null : new Genre(obj.Id, obj.Name);
		}

		public static List<GenreModel> FromEntitiesList(IEnumerable<Genre> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Genre> ToEntitiesList(IEnumerable<GenreModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BookGenreModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "IdGenre")]
		public int? IdGenre { get; set; }

		[Display(Name = "IdBook")]
		public int? IdBook { get; set; }

		public static BookGenreModel FromEntity(BookGenre obj)
		{
			return obj == null ? null : new BookGenreModel
			{
				Id = obj.Id,
				IdGenre = obj.IdGenre,
				IdBook = obj.IdBook,
			};
		}

		public static BookGenre ToEntity(BookGenreModel obj)
		{
			return obj == null ? null : new BookGenre(obj.Id, obj.IdGenre, obj.IdBook);
		}

		public static List<BookGenreModel> FromEntitiesList(IEnumerable<BookGenre> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<BookGenre> ToEntitiesList(IEnumerable<BookGenreModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BookAuthorModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Id Автора")]
		public int? IdAuthor { get; set; }

		[Display(Name = "Id Книги")]
		public int? IdBook { get; set; }

		public static BookAuthorModel FromEntity(BookAuthor obj)
		{
			return obj == null ? null : new BookAuthorModel
			{
				Id = obj.Id,
				IdAuthor = obj.IdAuthor,
				IdBook = obj.IdBook,
			};
		}

		public static BookAuthor ToEntity(BookAuthorModel obj)
		{
			return obj == null ? null : new BookAuthor(obj.Id, obj.IdAuthor, obj.IdBook);
		}

		public static List<BookAuthorModel> FromEntitiesList(IEnumerable<BookAuthor> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<BookAuthor> ToEntitiesList(IEnumerable<BookAuthorModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

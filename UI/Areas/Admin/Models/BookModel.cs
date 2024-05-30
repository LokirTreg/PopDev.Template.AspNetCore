using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class BookModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Книги")]
		public int Id { get; set; }

		[Display(Name = "Название")]
		public string Title { get; set; }

		[Display(Name = "Год издания")]
		public string YearOfPublish { get; set; }

		[Display(Name = "Тираж")]
		public int? Circulation { get; set; }

		[Display(Name = "Id Издателя")]
		public int? IdPublisher { get; set; }

		public static BookModel FromEntity(Book obj)
		{
			return obj == null ? null : new BookModel
			{
				Id = obj.Id,
				Title = obj.Title,
				YearOfPublish = obj.YearOfPublish,
				Circulation = obj.Circulation,
				IdPublisher = obj.IdPublisher,
			};
		}

		public static Book ToEntity(BookModel obj)
		{
			return obj == null ? null : new Book(obj.Id, obj.Title, obj.YearOfPublish, obj.Circulation,
				obj.IdPublisher);
		}

		public static List<BookModel> FromEntitiesList(IEnumerable<Book> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Book> ToEntitiesList(IEnumerable<BookModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

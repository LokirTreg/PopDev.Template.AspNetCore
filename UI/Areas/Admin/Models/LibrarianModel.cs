using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class LibrarianModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Библиотекаря")]
		public int Id { get; set; }

		[Display(Name = "Имя библиотекаря")]
		public string Name { get; set; }

		public static LibrarianModel FromEntity(Librarian obj)
		{
			return obj == null ? null : new LibrarianModel
			{
				Id = obj.Id,
				Name = obj.Name,
			};
		}

		public static Librarian ToEntity(LibrarianModel obj)
		{
			return obj == null ? null : new Librarian(obj.Id, obj.Name);
		}

		public static List<LibrarianModel> FromEntitiesList(IEnumerable<Librarian> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Librarian> ToEntitiesList(IEnumerable<LibrarianModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

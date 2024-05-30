using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class AuthorModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Автора")]
		public int Id { get; set; }

		[Display(Name = "Автор")]
		public string Name { get; set; }

		public static AuthorModel FromEntity(Author obj)
		{
			return obj == null ? null : new AuthorModel
			{
				Id = obj.Id,
				Name = obj.Name,
			};
		}

		public static Author ToEntity(AuthorModel obj)
		{
			return obj == null ? null : new Author(obj.Id, obj.Name);
		}

		public static List<AuthorModel> FromEntitiesList(IEnumerable<Author> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Author> ToEntitiesList(IEnumerable<AuthorModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

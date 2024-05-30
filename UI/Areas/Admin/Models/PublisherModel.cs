using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Common.Enums;
using Entities;

namespace UI.Areas.Admin.Models
{
	public class PublisherModel
	{
		[Required(ErrorMessage = "Укажите значение")]
		[Display(Name = "Id Издателя")]
		public int Id { get; set; }

		[Display(Name = "Название")]
		public string Title { get; set; }

		public static PublisherModel FromEntity(Publisher obj)
		{
			return obj == null ? null : new PublisherModel
			{
				Id = obj.Id,
				Title = obj.Title,
			};
		}

		public static Publisher ToEntity(PublisherModel obj)
		{
			return obj == null ? null : new Publisher(obj.Id, obj.Title);
		}

		public static List<PublisherModel> FromEntitiesList(IEnumerable<Publisher> list)
		{
			return list?.Select(FromEntity).ToList();
		}

		public static List<Publisher> ToEntitiesList(IEnumerable<PublisherModel> list)
		{
			return list?.Select(ToEntity).ToList();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Book
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string YearOfPublish { get; set; }
		public int? Circulation { get; set; }
		public int? IdPublisher { get; set; }

		public Book(int id, string title, string yearOfPublish, int? circulation, int? idPublisher)
		{
			Id = id;
			Title = title;
			YearOfPublish = yearOfPublish;
			Circulation = circulation;
			IdPublisher = idPublisher;
		}
	}
}

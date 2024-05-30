using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Publisher
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public Publisher(int id, string title)
		{
			Id = id;
			Title = title;
		}
	}
}

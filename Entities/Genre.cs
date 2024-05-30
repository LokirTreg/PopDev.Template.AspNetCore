using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Genre
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Genre(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}

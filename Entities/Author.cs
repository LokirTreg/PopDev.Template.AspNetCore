using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public Author(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}

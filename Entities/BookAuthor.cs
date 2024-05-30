using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class BookAuthor
	{
		public int Id { get; set; }
		public int? IdAuthor { get; set; }
		public int? IdBook { get; set; }

		public BookAuthor(int id, int? idAuthor, int? idBook)
		{
			Id = id;
			IdAuthor = idAuthor;
			IdBook = idBook;
		}
	}
}

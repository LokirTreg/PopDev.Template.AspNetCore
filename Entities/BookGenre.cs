using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class BookGenre
	{
		public int Id { get; set; }
		public int? IdGenre { get; set; }
		public int? IdBook { get; set; }

		public BookGenre(int id, int? idGenre, int? idBook)
		{
			Id = id;
			IdGenre = idGenre;
			IdBook = idBook;
		}
	}
}

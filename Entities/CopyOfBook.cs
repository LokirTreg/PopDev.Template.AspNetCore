using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class CopyOfBook
	{
		public int Id { get; set; }
		public int? IdBook { get; set; }

		public CopyOfBook(int id, int? idBook)
		{
			Id = id;
			IdBook = idBook;
		}
	}
}

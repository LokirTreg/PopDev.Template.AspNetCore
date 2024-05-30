using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Debtor
	{
		public int Id { get; set; }
		public int? IdIssuedBook { get; set; }

		public Debtor(int id, int? idIssuedBook)
		{
			Id = id;
			IdIssuedBook = idIssuedBook;
		}
	}
}

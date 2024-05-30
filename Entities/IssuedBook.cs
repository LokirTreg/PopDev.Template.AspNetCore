using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class IssuedBook
	{
		public int Id { get; set; }
		public DateTime? DateOfIssue { get; set; }
		public DateTime? DateOfPlannedDelivery { get; set; }
		public int? IdReader { get; set; }
		public int? IdLibrarian { get; set; }
		public int? IdCopyOfBook { get; set; }

		public IssuedBook(int id, DateTime? dateOfIssue, DateTime? dateOfPlannedDelivery, int? idReader,
			int? idLibrarian, int? idCopyOfBook)
		{
			Id = id;
			DateOfIssue = dateOfIssue;
			DateOfPlannedDelivery = dateOfPlannedDelivery;
			IdReader = idReader;
			IdLibrarian = idLibrarian;
			IdCopyOfBook = idCopyOfBook;
		}
	}
}

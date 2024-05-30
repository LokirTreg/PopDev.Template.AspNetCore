using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Queue
	{
		public int Id { get; set; }
		public int? NumberInQueue { get; set; }
		public int? IdReader { get; set; }
		public int? IdBook { get; set; }

		public Queue(int id, int? numberInQueue, int? idReader, int? idBook)
		{
			Id = id;
			NumberInQueue = numberInQueue;
			IdReader = idReader;
			IdBook = idBook;
		}
	}
}

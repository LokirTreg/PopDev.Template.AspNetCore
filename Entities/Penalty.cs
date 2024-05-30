using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class Penalty
	{
		public int Id { get; set; }
		public int? SizeOfPenalty { get; set; }

		public Penalty(int id, int? sizeOfPenalty)
		{
			Id = id;
			SizeOfPenalty = sizeOfPenalty;
		}
	}
}

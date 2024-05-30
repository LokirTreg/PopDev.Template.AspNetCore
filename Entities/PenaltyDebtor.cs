using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enums;

namespace Entities
{
	public class PenaltyDebtor
	{
		public int Id { get; set; }
		public int? IdPenalty { get; set; }
		public int? IdDebtor { get; set; }

		public PenaltyDebtor(int id, int? idPenalty, int? idDebtor)
		{
			Id = id;
			IdPenalty = idPenalty;
			IdDebtor = idDebtor;
		}
	}
}

using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class DebtorSearchParams : BaseSearchParams
	{
		public DebtorSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}

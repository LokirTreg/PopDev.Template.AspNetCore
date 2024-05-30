using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class ReaderSearchParams : BaseSearchParams
	{
		public ReaderSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}

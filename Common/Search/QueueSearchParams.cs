using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class QueueSearchParams : BaseSearchParams
	{
		public QueueSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}

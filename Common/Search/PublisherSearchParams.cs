using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class PublisherSearchParams : BaseSearchParams
	{
		public PublisherSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}

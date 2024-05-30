using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class Book_AuthorSearchParams : BaseSearchParams
	{
		public Book_AuthorSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}

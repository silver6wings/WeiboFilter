using System;
using System.Collections.Generic;
using System.Text;

namespace NetDimension.Weibo.Entities.trend
{
	public class Keyword : EntityBase
	{
		public string Name { get; internal set; }
		public string Query {get;internal set;}
		public string Amount { get; internal set; }
		public string Delta { get; internal set; }
	}
}

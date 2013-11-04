using System;
using System.Collections.Generic;
using System.Text;
using NetDimension.Json;

namespace NetDimension.Weibo.Entities.tag
{
	public class Tag : EntityBase
	{
		
		public string ID { get; internal set; }
		public string Name { get; internal set; }
		public string Weight { get; internal set; }
	}
}

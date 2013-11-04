using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetDimension.Weibo.Interface
{
	/// <summary>
	/// 接口选择器
	/// </summary>
	public class InterfaceSelector
	{
		/// <summary>
		/// 动态类型API调用
		/// </summary>
		public DynamicInterfaces Dynamic
		{
			get;
			internal set;
		}
		/// <summary>
		/// 实体类型API调用哪个
		/// </summary>
		public EntityInterfaces Entity
		{
			get;
			internal set;
		}

		internal InterfaceSelector(Client client)
		{
			Dynamic = new DynamicInterfaces(client);
			Entity = new EntityInterfaces(client);
		}
	}
}

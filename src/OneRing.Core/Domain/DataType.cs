using System;

namespace OneRing.Core.Domain
{
	public class DataType : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string NativeName { get; set; }
	}
}

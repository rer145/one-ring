using System;

namespace OneRing.Core.Domain.Actions
{
	public class ActionMethodParameter : BaseEntity
	{
		public int ActionMethodId { get; set; }
		public ActionMethod ActionMethod { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FullyQualifiedName { get; set; }
		public int DataTypeId { get; set; }
		public DataType DataType { get; set; }
	}
}

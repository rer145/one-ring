using System;

namespace OneRing.Core.Domain.Actions
{
	public class ActionLibrary : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string FullyQualifiedName { get; set; }
	}
}

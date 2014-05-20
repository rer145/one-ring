using System;

namespace OneRing.Core.Domain.Actions
{
	public class ActionMethod : BaseEntity
	{
		public int ActionLibraryId { get; set; }
		public ActionLibrary ActionLibrary { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FullyQualifiedName { get; set; }
	}
}

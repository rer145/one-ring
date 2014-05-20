using System;

namespace OneRing.Core
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
	}
}
using System;

namespace OneRing.Core
{
	public class BaseAuditEntity : BaseEntity
	{
		public int CreatedBy { get; set; }
		public DateTime CreatedOn { get; set; }
		public int LastModifiedBy { get; set; }
		public DateTime LastModifiedOn { get; set; }
		public int DeletedBy { get; set; }
		public DateTime DeletedOn { get; set; }
	}
}
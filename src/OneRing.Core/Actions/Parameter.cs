using System;

using OneRing.Core.Enums;

namespace OneRing.Core.Actions
{
	public class Parameter
	{
		public string Name { get; set; }
		public ElementType Type { get; set; }
		public object Value { get; set; }
	}
}
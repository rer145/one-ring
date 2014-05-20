using System.ComponentModel.DataAnnotations;

namespace OneRing.Core.Enums
{
	public enum OperatorType
	{
		[Display(Name = "Equal To")]
		Equals,

		[Display(Name = "Not Equal To")]
		NotEquals,

		[Display(Name = "Between (Inclusive)")]
		BetweenInclusive,

		[Display(Name = "Between (Exclusive)")]
		BetweenExclusive,

		[Display(Name = "Greater Than")]
		GreaterThan,

		[Display(Name = "Greater Than or Equal To")]
		GreaterThanOrEquals,

		[Display(Name = "Less Than")]
		LessThan,

		[Display(Name = "Less Than or Equal To")]
		LessThanOrEquals,

		[Display(Name = "Contains")]
		Contains,

		[Display(Name = "Comes Before")]
		ComesBefore,

		[Display(Name = "Comes After")]
		ComesAfter,

		[Display(Name = "Matches Regular Expression")]
		IsRegExMatch
	}
}
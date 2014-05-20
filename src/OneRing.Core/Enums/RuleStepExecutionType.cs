using System;
using System.ComponentModel.DataAnnotations;

namespace OneRing.Core.Enums
{
	public enum RuleStepExecutionType
	{
		[Display(Name="All or Nothing (Transaction)")]
		AllOrNothing,

		[Display(Name="One at a time")]
		OneAtATime
	}
}

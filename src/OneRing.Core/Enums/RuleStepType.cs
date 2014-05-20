using System;
using System.ComponentModel.DataAnnotations;

namespace OneRing.Core.Enums
{
	public enum RuleStepType
	{
		[Display(Name="Evaluation")]
		Evaluation,

		[Display(Name="Action")]
		Action
	}
}

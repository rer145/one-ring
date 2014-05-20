using System;

using OneRing.Core.Enums;

namespace OneRing.Core.Domain.Rules
{
	public class RuleStep : BaseAuditEntity
	{
		public int RuleId { get; set; }
		public Rule Rule { get; set; }
		public int Sequence { get; set; }
		public RuleStepExecutionType ExecutionType { get; set; }
		public RuleStepType StepType { get; set; }
		public int SuccessRuleStepId { get; set; }
		public RuleStep SuccessRuleStep { get; set; }
		public int FailRuleStepId { get; set; }
		public RuleStep FailRuleStep { get; set; }
	}
}

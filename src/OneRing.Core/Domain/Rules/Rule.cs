using System;
using System.Collections.Generic;

using OneRing.Core.Enums;
using OneRing.Core.Domain.Evaluations;

namespace OneRing.Core.Domain.Rules
{
	public class Rule : BaseAuditEntity
	{
		private IList<OneRing.Core.Domain.Evaluations.Evaluation> Evaluations;

		public string Name { get; set; }
		public string Description { get; set; }
		public RuleStatus Status { get; set; }
	}
}

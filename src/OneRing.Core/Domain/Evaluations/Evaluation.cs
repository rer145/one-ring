using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OneRing.Core.Domain.Rules;

namespace OneRing.Core.Domain.Evaluations
{
	public class Evaluation : BaseAuditEntity
	{
		private IList<EvaluationDetail> EvaluationDetails;

		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsReusable { get; set; }
		public int RuleId { get; set; }
		public Rule Rule { get; set; }
	}
}
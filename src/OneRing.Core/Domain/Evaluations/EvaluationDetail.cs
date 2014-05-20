using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OneRing.Core.Enums;

namespace OneRing.Core.Domain.Evaluations
{
	public class EvaluationDetail : BaseAuditEntity
	{
		public int EvaluationId { get; set; }
		public Evaluation Evaluation { get; set; }
		public ElementType Operand1Type { get; set; }
		public IComparable Operand1Value { get; set; }
		public OperatorType Operator { get; set; }
		public ElementType Operand2Type { get; set; }
		public IComparable Operand2Value { get; set; }
	}
}
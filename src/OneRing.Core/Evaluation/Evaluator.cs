using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using OneRing.Core.Domain;
using OneRing.Core.Domain.Evaluations;
using OneRing.Core.Enums;

namespace OneRing.Core.Evaluation
{
	public static class Evaluator
	{
		public static bool Evaluate(IComparable value1, IComparable value2, OperatorType operatorType)
		{
			bool result = false;

			switch (operatorType)
			{
				case OperatorType.Equals:
					result = (value1.CompareTo(value2) == 0);
					break;
				case OperatorType.NotEquals:
					result = (value1.CompareTo(value2) != 0);
					break;
				case OperatorType.GreaterThan:
					result = (value1.CompareTo(value2) > 0);
					break;
				case OperatorType.LessThan:
					result = (value1.CompareTo(value2) < 0);
					break;
				case OperatorType.GreaterThanOrEquals:
					result = (value1.CompareTo(value2) >= 0);
					break;
				case OperatorType.LessThanOrEquals:
					result = (value1.CompareTo(value2) <= 0);
					break;
				case OperatorType.ComesAfter:
					result = (value1.CompareTo(value2) > 0);
					break;
				case OperatorType.ComesBefore:
					result = (value1.CompareTo(value2) < 0);
					break;
				case OperatorType.IsRegExMatch:
					result = Regex.IsMatch(value1.ToString(), value2.ToString(), RegexOptions.None);
					break;
				case OperatorType.BetweenInclusive:
					throw new NotImplementedException();		//These should be handled via the UI and basically build 2 evaluation conditions 
				case OperatorType.BetweenExclusive:
					throw new NotImplementedException();
				case OperatorType.Contains:
					throw new NotImplementedException();
			}

			return result;
		}

		public static bool Evaluate(OneRing.Core.Domain.Evaluations.Evaluation evaluation, IList<EvaluationDetail> evaluationDetails)
		{
			if (evaluation == null)
				throw new ArgumentNullException("evaluation");

			if (evaluationDetails == null)
				throw new ArgumentNullException("evaluationDetails");

			
			//evaluate all conditions in group
			//assume an AND grouping and break on first failure
			bool result = true;
			foreach (var item in evaluationDetails)
			{
				result = Evaluate(item.Operand1Value, item.Operand2Value, item.Operator);
				if (!result)
					break;
			}

			return result;
		}
	}
}
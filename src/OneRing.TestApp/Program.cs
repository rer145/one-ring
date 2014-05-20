using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using OneRing.Core.Actions;
using OneRing.Core.Domain;
using OneRing.Core.Domain.Evaluations;
using OneRing.Core.Enums;
using OneRing.Core.Evaluation;

namespace OneRing.TestApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("PERFORMING BASIC DATA TYPE EVALUATIONS......");

			int int1 = 0;
			int int2 = 2;

			string string1 = "abc";
			string string2 = "def";

			CustomObject obj1 = new CustomObject()
			{
				Id = 1,
				Name = "Ron"
			};

			CustomObject obj2 = new CustomObject()
			{
				Id = 1,
				Name = "Ron"
			};


			Array operators = Enum.GetValues(typeof(OperatorType));
			foreach (var item in operators)
			{
				Console.WriteLine("Testing evaluations for: " + item.ToString());
				try
				{
					Console.WriteLine("  int (" + int1.ToString() + " vs " + int2.ToString() + "): " + Evaluator.Evaluate(int1, int2, (OperatorType)Enum.Parse(typeof(OperatorType), item.ToString())));
					Console.WriteLine("  string (" + string1 + " vs " + string2 + "): " + Evaluator.Evaluate(string1, string2, (OperatorType)Enum.Parse(typeof(OperatorType), item.ToString())));
					Console.WriteLine("  custom (" + obj1.ToString() + " vs " + obj2.ToString() + "): " + Evaluator.Evaluate(obj1, obj2, (OperatorType)Enum.Parse(typeof(OperatorType), item.ToString())));
				}
				catch (NotImplementedException)
				{
					Console.WriteLine("  Not yet implemented");
				}

				Console.WriteLine();
			}


			Console.WriteLine();
			Console.WriteLine("PERFORMING EVALUATION COLLECTIONS AND ACTION PERFORMING......");

			string fqn = "OneRing.Core.Actions.SendEmailAction, OneRing.Core";

			//pull stuff from database
			Evaluation eval = new Evaluation();
			eval.Id = 1;
			eval.Name = "Test Evaluation";

			List<EvaluationDetail> evals = new List<EvaluationDetail>();
			evals.Add(new EvaluationDetail()
			{
				Evaluation = eval,
				EvaluationId = eval.Id,
				Operand1Type = ElementType.Static,
				Operand1Value = int1,
				Operand2Type = ElementType.Static,
				Operand2Value = int2,
				Operator = OperatorType.ComesBefore
			});
			evals.Add(new EvaluationDetail()
			{
				Evaluation = eval,
				EvaluationId = eval.Id,
				Operand1Type = ElementType.Static,
				Operand1Value = string1,
				Operand2Type = ElementType.Static,
				Operand2Value = string2,
				Operator = OperatorType.NotEquals
			});
			evals.Add(new EvaluationDetail()
			{
				Evaluation = eval,
				EvaluationId = eval.Id,
				Operand1Type = ElementType.Static,
				Operand1Value = obj1,
				Operand2Type = ElementType.Static,
				Operand2Value = obj2,
				Operator = OperatorType.Equals
			});

			bool evalResult = Evaluator.Evaluate(eval, evals);
			if (evalResult)
			{
				List<string> to = new List<string>();
				to.Add("ronrichardson@gmail.com");

				List<Parameter> parameters = new List<Parameter>();
				parameters.Add(new Parameter() { Name = "Subject", Value = "This is a test email", Type = ElementType.Static });
				parameters.Add(new Parameter() { Name = "FromEmail", Value = "ron.richardson@gmail.com", Type = ElementType.Static });
				parameters.Add(new Parameter() { Name = "Body", Value = "Wonderful body message goes here.", Type = ElementType.Static });
				parameters.Add(new Parameter() { Name = "IsBodyHtml", Value = false, Type = ElementType.Static });
				parameters.Add(new Parameter() 
				{ 
					Name = "ToEmails", 
					Value = to, 
					Type = ElementType.Static
				});
				//parameters.Add(new Parameter() { Name = "CcEmails", Value = "This is a test email", Type = ElementType.Static });
				//parameters.Add(new Parameter() { Name = "BccEmails", Value = "This is a test email", Type = ElementType.Static });

				
				Console.WriteLine("Send email properties...");
				Type type = Type.GetType(fqn);
				if (type == null)
				{
					Console.WriteLine("Unable to load type..");
				}
				else
				{
					Console.WriteLine("type: " + type.Name);
					Console.WriteLine("Total properties: " + type.GetProperties().Count().ToString());

					var action = (BaseAction)Activator.CreateInstance(type);
					action.ApplyParameters(parameters);
					ActionResult result = action.Execute();
					
					Console.WriteLine("action successful: " + result.WasSuccessful.ToString());
					if (result.WasSuccessful)
					{
						Console.WriteLine("success messages:");
						foreach (var x in result.SuccessMessages)
							Console.WriteLine("--" + x);
					}
					else
					{
						Console.WriteLine("error messages:");
						foreach (var x in result.ErrorMessages)
							Console.WriteLine("--" + x);
					}

					Console.WriteLine("warning messages:");
					foreach (var x in result.WarningMessages)
						Console.WriteLine("--" + x);
				}
				
			}
			else
			{
				Console.WriteLine("Evaluation failed! No action performed");
			}

			
			Console.WriteLine();
			Console.WriteLine("done");
			Console.ReadLine();
			
		}
	}
}
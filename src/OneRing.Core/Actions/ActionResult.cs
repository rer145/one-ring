using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRing.Core.Actions
{
	public class ActionResult
	{
		public bool WasSuccessful { get; set; }
		public IList<string> ErrorMessages { get; set; }
		public IList<string> SuccessMessages { get; set; }
		public IList<string> WarningMessages { get; set; }

		public ActionResult()
		{
			this.WasSuccessful = false;
			this.ErrorMessages = new List<string>();
			this.SuccessMessages = new List<string>();
			this.WarningMessages = new List<string>();
		}
	}
}

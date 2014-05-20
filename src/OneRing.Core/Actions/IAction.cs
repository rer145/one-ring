using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRing.Core.Actions
{
	public interface IAction
	{
		ActionResult Execute();
	}
}
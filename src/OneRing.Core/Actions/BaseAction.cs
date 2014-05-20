using System;
using System.Collections.Generic;
using System.Reflection;

namespace OneRing.Core.Actions
{
	public abstract class BaseAction : IAction
	{
		public abstract ActionResult Execute();
	}
}

using System;
using System.Collections.Generic;
using System.Reflection;

namespace OneRing.Core.Actions
{
	public static class ActionExtensions
	{
		public static void ApplyParameters(this BaseAction action, IList<Parameter> parameters)
		{
			Type type = action.GetType();
			PropertyInfo[] properties = type.GetProperties();
			object propertyValue = String.Empty;

			for (int i = 0; i < properties.Length; i++)
			{
				//HACK: looping params each time, ugh.
				foreach (var p in parameters)
				{
					if (p.Name == properties[i].Name)
					{
						//TODO: grab value based on element type, assume static for now
						propertyValue = p.Value;
						if (propertyValue == null) propertyValue = String.Empty;

						properties[i].SetValue(action, propertyValue, null);
					}
				}
			}
		}
	}
}
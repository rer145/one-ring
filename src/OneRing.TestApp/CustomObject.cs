using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneRing.TestApp
{
	public class CustomObject : IComparable
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public CustomObject() { }

		public override string ToString()
		{
			return this.Id.ToString() + "/" + this.Name;
		}
		
		public int CompareTo(object obj)
		{
			if (obj == null)
				return 1;

			CustomObject otherObj = obj as CustomObject;
			if (otherObj == null)
				throw new ArgumentNullException("Object is not a CustomObject.");

			//compare base properties, or come up with other scheme
			return this.Id.CompareTo(otherObj.Id);

			/*
				Notes to Implementers
				For objects A, B and C, the following must be true:
				A.CompareTo(A) must return zero.
				If A.CompareTo(B) returns zero, then B.CompareTo(A) must return zero.
				If A.CompareTo(B) returns zero and B.CompareTo(C) returns zero, then A.CompareTo(C) must return zero.
				If A.CompareTo(B) returns a value other than zero, then B.CompareTo(A) must return a value of the opposite sign.
				If A.CompareTo(B) returns a value x not equal to zero, and B.CompareTo(C) returns a value y of the same sign as x, then A.CompareTo(C) must return a value of the same sign as x and y.
			*/

		}
	}
}
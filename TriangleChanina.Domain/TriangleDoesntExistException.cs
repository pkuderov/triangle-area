using System;

namespace TriangleChanina.Domain
{
	public class TriangleDoesntExistException : Exception
	{
		public TriangleDoesntExistException(double x, double y, double z)
			: base(string.Format("Configuration ({0}, {1}, {2}) doesn't set valid triangle", x, y, z))
		{ }
	}
}

using System;

namespace TriangleChanina.Domain
{
	public static class Triangle
	{
		public static double GetArea(double x, double y, double z)
		{
			EnsureTiangleExists(x, y, z);
			
			var s = (x + y + z) / 2.0;
			return Math.Sqrt(s * (s - x) * (s - y) * (s - z));
		}

		public static void EnsureTiangleExists(double x, double y, double z)
		{
			if (!(x > 0 && y > 0 && z > 0))
				throw new TriangleDoesntExistException(x, y, z);

			if ((x <= z - y && y <= z - x)
				|| (y <= x - z && z <= x - y)
				|| (z <= y - x && x <= y - z)
			)
			{
				throw new TriangleDoesntExistException(x, y, z);
			}
		}

	}
}
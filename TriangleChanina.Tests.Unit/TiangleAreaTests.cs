using System;
using NUnit.Framework;
using TriangleChanina.Domain;

namespace TriangleChanina.Tests.Unit
{
	[TestFixture]
	public class TiangleAreaTests
	{
		[SetUp]
		public void SetUp() { }

		[Test]
		void When_AtLeastOneSideIsntPositive_Then_ThrowDoesntExist()
		{
			// just shortage
			Func<TestDelegate, TriangleDoesntExistException> assert = Assert.Throws<TriangleDoesntExistException>;

			assert(() => Triangle.EnsureTiangleExists(0, 0, 0));
			Triangle.EnsureTiangleExists(double.Epsilon, double.Epsilon, double.Epsilon);
		}

	}
}

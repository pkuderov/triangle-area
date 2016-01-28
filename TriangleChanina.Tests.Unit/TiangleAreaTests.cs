using System;
using NUnit.Framework;
using TriangleChanina.Domain;

namespace TriangleChanina.Tests.Unit
{
	[TestFixture]
	public class TiangleAreaTests
	{

		[Test]
		public void When_AtLeastOneSideIsntPositive_Then_ThrowDoesntExist()
		{
			Assert.Throws<TriangleDoesntExistException>(() => Triangle.EnsureTiangleExists(0, 0, 0));
			Assert.Throws<TriangleDoesntExistException>(() => Triangle.EnsureTiangleExists(-1, 0, 1));

			Triangle.EnsureTiangleExists(double.Epsilon, double.Epsilon, double.Epsilon);
			Triangle.EnsureTiangleExists(4, 2, 3);
		}

		[Test]
		public void When_OneSideNotLessThanSumOfTheOthers_Then_ThrowDoesntExist()
		{
			Assert.Throws<TriangleDoesntExistException>(() => Triangle.EnsureTiangleExists(1, 2, 3));
			Assert.Throws<TriangleDoesntExistException>(() => Triangle.EnsureTiangleExists(4, 2, 1));

			Triangle.EnsureTiangleExists(1, 1, double.Epsilon);
			Triangle.EnsureTiangleExists(double.MaxValue, double.MaxValue, double.MaxValue);
			Triangle.EnsureTiangleExists(double.MaxValue, double.MaxValue, double.Epsilon);
		}

		[Test]
		public void Given_CorrectSides_And_AreaByTwoSidesAndSinus_Then_AreaAndAreaByHeronsFormulaShouldBeEqual()
		{
			Assert.AreEqual(Triangle.GetArea(3, 4, 5), 6, double.Epsilon);
			Assert.AreEqual(Triangle.GetArea(double.MaxValue, double.MaxValue, double.MaxValue), double.PositiveInfinity);
			Assert.AreEqual(Triangle.GetArea(double.MaxValue, double.Epsilon, double.MaxValue), double.PositiveInfinity);
			Assert.AreEqual(0.34197, Triangle.GetArea(1.0, 0.9, 0.8), 0.99e-5);
			
			Assert.AreEqual(5e+4, Triangle.GetArea(1e+10, 1e+10, 1e-5), 1);
		}

		private static double FromGrades(double g)
		{
			return g * Math.PI / 180.0;
		}
	}
}

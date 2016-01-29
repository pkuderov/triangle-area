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
			Assert.AreEqual(double.PositiveInfinity, Triangle.GetArea(double.MaxValue, double.MaxValue, double.MaxValue));
			Assert.AreEqual(double.PositiveInfinity, Triangle.GetArea(double.MaxValue, double.Epsilon, double.MaxValue));
			Assert.AreEqual(0, Triangle.GetArea(1, 1, double.Epsilon), double.Epsilon);
			Assert.AreEqual(0, Triangle.GetArea(1e+10, 1e+10, 1e-10), double.Epsilon);

			// assert symmetry of operation
			Assert.AreEqual(6, Triangle.GetArea(3, 4, 5), double.Epsilon);
			Assert.AreEqual(6, Triangle.GetArea(5, 4, 3), double.Epsilon);
			Assert.AreEqual(6, Triangle.GetArea(5, 3, 4), double.Epsilon);

			// calculated in google online calc - low accurancy
			Assert.AreEqual(0.34197, Triangle.GetArea(1.0, 0.9, 0.8), 1.0e-6);
			
			// s = 7.25, area^2 = 20.20484375, calculated in windows calc
			// + assert symmetry
			Assert.AreEqual(4.494979838664463, Triangle.GetArea(7, 2.7, 4.8), 1.0e-6);
			Assert.AreEqual(4.494979838664463, Triangle.GetArea(2.7, 4.8, 7), 1.0e-6);
			Assert.AreEqual(4.494979838664463, Triangle.GetArea(4.8, 7, 2.7), 1.0e-6);
		}
	}
}

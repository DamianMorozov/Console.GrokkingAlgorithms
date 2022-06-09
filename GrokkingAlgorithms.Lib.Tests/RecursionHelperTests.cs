// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Diagnostics;

namespace GrokkingAlgorithms.Lib.Tests
{
    [TestFixture]
	public class RecursionHelperTests
	{
		private readonly RecursionHelper _recursionHelper = RecursionHelper.Instance;

		/// <summary>
		/// Setup private fields.
		/// </summary>
		[SetUp]
		public void Setup()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Setup)} start.");
			// 
			TestContext.WriteLine($@"{nameof(Setup)} complete.");
		}

		/// <summary>
		/// Reset private fields to default state.
		/// </summary>
		[TearDown]
		public void Teardown()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Teardown)} start.");
			// 
			TestContext.WriteLine($@"{nameof(Teardown)} complete.");
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
		}

		[Test]
		public void Factorial_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Factorial_AreEqual)} start.");
			Stopwatch sw = Stopwatch.StartNew();

			Assert.AreEqual(-5, _recursionHelper.Factorial(-5));
			Assert.AreEqual(-4, _recursionHelper.Factorial(-4));
			Assert.AreEqual(-3, _recursionHelper.Factorial(-3));
			Assert.AreEqual(-2, _recursionHelper.Factorial(-2));
			Assert.AreEqual(-1, _recursionHelper.Factorial(-1));
			Assert.AreEqual(0, _recursionHelper.Factorial(0));
			Assert.AreEqual(1, _recursionHelper.Factorial(1));
			Assert.AreEqual(2, _recursionHelper.Factorial(2));
			Assert.AreEqual(6, _recursionHelper.Factorial(3));
			Assert.AreEqual(24, _recursionHelper.Factorial(4));
			Assert.AreEqual(120, _recursionHelper.Factorial(5));

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Factorial_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
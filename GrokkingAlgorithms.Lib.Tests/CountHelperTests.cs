// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GrokkingAlgorithms.Lib.Tests
{
    [TestFixture]
	public class CountHelperTests
	{
		private readonly CountHelper _countHelper = CountHelper.Instance;
		private readonly ArrayHelper _arrayHelper = ArrayHelper.Instance;

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
		public void Execute_Slow_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Execute_Slow_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			// null
			var arr = _arrayHelper.RandomArray(0, 1_000);
			int actual = _countHelper.Execute(arr, EnumSpeed.Slow);
			int expected = 0;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// null list
			actual = _countHelper.Execute(new List<int?>(), EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			arr = _arrayHelper.RandomArray(2_123, 1_000);
			actual = _countHelper.Execute(arr, EnumSpeed.Slow);
			expected = 2_123;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			
			// list
			actual = _countHelper.Execute(arr.ToList(), EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_Slow_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

		[Test]
		public void Execute_Fast_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Execute_Fast_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			// null
			var arr = _arrayHelper.RandomArray(0, 1_000);
			int actual = _countHelper.Execute(arr);
			int expected = 0;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// null list
			actual = _countHelper.Execute(new List<int?>());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			expected = 2_123;
			arr = _arrayHelper.RandomArray(2_123, 1_000);
			actual = _countHelper.Execute(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// list
			actual = _countHelper.Execute(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_Fast_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
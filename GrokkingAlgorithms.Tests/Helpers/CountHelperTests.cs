// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GrokkingAlgorithms.Tests.Helpers
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
		public void ExecuteRecursive_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(ExecuteRecursive_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			// null
			var arr = _arrayHelper.GetRandomArray(0, 1_000);
			int actual = _countHelper.ExecuteRecursive(arr);
			int expected = 0;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// null list
			actual = _countHelper.ExecuteRecursive(new List<int?>());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			arr = _arrayHelper.GetRandomArray(2_123, 1_000);
			actual = _countHelper.ExecuteRecursive(arr);
			expected = 2_123;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			
			// list
			actual = _countHelper.ExecuteRecursive(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(ExecuteRecursive_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

		[Test]
		public void ExecuteForeach_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(ExecuteForeach_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			// null
			var arr = _arrayHelper.GetRandomArray(0, 1_000);
			int actual = _countHelper.ExecuteForeach(arr);
			int expected = 0;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// null list
			actual = _countHelper.ExecuteForeach(new List<int?>());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			expected = 2_123;
			arr = _arrayHelper.GetRandomArray(2_123, 1_000);
			actual = _countHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// list
			actual = _countHelper.ExecuteForeach(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(ExecuteForeach_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
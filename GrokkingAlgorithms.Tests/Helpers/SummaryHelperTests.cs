// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace GrokkingAlgorithms.Tests.Helpers
{
	[TestFixture]
	public class SummaryHelperTests
	{
		private readonly SummaryHelper _summaryHelper = SummaryHelper.Instance;
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
		public void ExecuteForeach_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(ExecuteForeach_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			var arr = _arrayHelper.GetSortArray(0, 10, EnumSort.Asc);
			int expected = 55;
			int actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteForeach(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.GetSortArray(10, 0, EnumSort.Desc);
			actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteForeach(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			arr = _arrayHelper.GetSortArray(2001, 2003, EnumSort.Asc);
			expected = 6006;
			actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteForeach(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.GetSortArray(2003, 2001, EnumSort.Desc);
			actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteForeach(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(ExecuteForeach_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

		[Test]
		public void ExecuteRecursive_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(ExecuteRecursive_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			var arr = _arrayHelper.GetSortArray(0, 10, EnumSort.Asc);
			int expected = 55;
			int actual = _summaryHelper.ExecuteRecursive(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteRecursive(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.GetSortArray(10, 0, EnumSort.Desc);
			actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteRecursive(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			arr = _arrayHelper.GetSortArray(2001, 2003, EnumSort.Asc);
			expected = 6006;
			actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteRecursive(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.GetSortArray(2003, 2001, EnumSort.Desc);
			actual = _summaryHelper.ExecuteForeach(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.ExecuteRecursive(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(ExecuteRecursive_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
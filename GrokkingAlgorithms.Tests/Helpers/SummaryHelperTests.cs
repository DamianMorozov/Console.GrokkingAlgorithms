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
		public void Execute_Fast_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Execute_Fast_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			var arr = _arrayHelper.SortArray(0, 10, EnumSortDirection.Asc);
			int expected = 55;
			int actual = _summaryHelper.Execute(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.SortArray(10, 0, EnumSortDirection.Desc);
			actual = _summaryHelper.Execute(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			arr = _arrayHelper.SortArray(2001, 2003, EnumSortDirection.Asc);
			expected = 6006;
			actual = _summaryHelper.Execute(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.SortArray(2003, 2001, EnumSortDirection.Desc);
			actual = _summaryHelper.Execute(arr);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList());
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_Fast_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

		[Test]
		public void Execute_Slow_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Execute_Slow_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			var arr = _arrayHelper.SortArray(0, 10, EnumSortDirection.Asc);
			int expected = 55;
			int actual = _summaryHelper.Execute(arr, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList(), EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.SortArray(10, 0, EnumSortDirection.Desc);
			actual = _summaryHelper.Execute(arr, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList(), EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			arr = _arrayHelper.SortArray(2001, 2003, EnumSortDirection.Asc);
			expected = 6006;
			actual = _summaryHelper.Execute(arr, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList(), EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.SortArray(2003, 2001, EnumSortDirection.Desc);
			actual = _summaryHelper.Execute(arr, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _summaryHelper.Execute(arr.ToList(), EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_Slow_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
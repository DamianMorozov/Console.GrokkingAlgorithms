// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Diagnostics;
	
namespace GrokkingAlgorithms.Tests.Helpers
{
	[TestFixture]
	public class SortHelperTests
	{
		private readonly SortHelper _sortHelper = SortHelper.Instance;
		private readonly ArrayHelper _arrayHelper = ArrayHelper.Instance;
        private readonly int?[] _expectedAsc = { 2110, 2111, 2112, 2113, 2114, 2115, 2116, 2117, 2118, 2119, 2120 };
        private readonly int?[] _expectedDesc = { 2120, 2119, 2118, 2117, 2116, 2115, 2114, 2113, 2112, 2111, 2110 };

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
		public void ExecuteSelection_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(ExecuteSelection_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

			var actual = _arrayHelper.SortArray(2110, 2120, EnumSortDirection.Asc);
			_sortHelper.ExecuteSelection(actual, EnumSortDirection.Desc, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedDesc, actual);
			_sortHelper.ExecuteSelection(actual, EnumSortDirection.Asc, EnumSpeed.Slow);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedAsc, actual);

			_sortHelper.ExecuteSelection(actual, EnumSortDirection.Desc, EnumSpeed.Middle);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedDesc, actual);
			_sortHelper.ExecuteSelection(actual, EnumSortDirection.Asc, EnumSpeed.Middle);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedAsc, actual);

			_sortHelper.ExecuteSelection(actual, EnumSortDirection.Desc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedDesc, actual);
			_sortHelper.ExecuteSelection(actual, EnumSortDirection.Asc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedAsc, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(ExecuteSelection_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

		[Test]
		public void GetExecuteSelection_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(GetExecuteSelection_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

			var arr = _arrayHelper.SortArray(2110, 2120, EnumSortDirection.Asc);
			var actual = _sortHelper.GetExecuteSelection(arr, EnumSortDirection.Desc, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedDesc, actual);
            actual = _sortHelper.GetExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Slow);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedAsc, actual);

            actual = _sortHelper.GetExecuteSelection(arr, EnumSortDirection.Desc, EnumSpeed.Middle);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedDesc, actual);
            actual = _sortHelper.GetExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Middle);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedAsc, actual);

            actual = _sortHelper.GetExecuteSelection(arr, EnumSortDirection.Desc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedDesc, actual);
            actual = _sortHelper.GetExecuteSelection(arr, EnumSortDirection.Asc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
			Assert.AreEqual(_expectedAsc, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(GetExecuteSelection_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

        [Test]
        public void ExecuteQuickGet_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(ExecuteQuickGet_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var arr = _arrayHelper.SortArray(2110, 2120, EnumSortDirection.Asc);
            var actual = _sortHelper.GetExecuteQuick(arr, EnumSortDirection.Asc, EnumSpeed.Slow);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedAsc, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(ExecuteQuickGet_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

	}
}
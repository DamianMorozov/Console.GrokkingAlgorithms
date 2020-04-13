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
		public void Selection_Execute_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Selection_Execute_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

			var arr = _arrayHelper.GetSortArray(2110, 2120, EnumSortDirection.Asc);
			_sortHelper.ExecuteSelection(arr, EnumSortDirection.Desc, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(_expectedDesc, arr);
			_sortHelper.ExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(_expectedAsc, arr);

			_sortHelper.ExecuteSelection(arr, EnumSortDirection.Desc, EnumSpeed.Middle);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(_expectedDesc, arr);
			_sortHelper.ExecuteSelection(arr, EnumSortDirection.Asc, EnumSpeed.Middle);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(_expectedAsc, arr);

			_sortHelper.ExecuteSelection(arr, EnumSortDirection.Desc);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(_expectedDesc, arr);
			_sortHelper.ExecuteSelection(arr, EnumSortDirection.Asc);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(_expectedAsc, arr);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Selection_Execute_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

        [Test]
        public void Quick_Execute_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Quick_Execute_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var arr = _arrayHelper.GetSortArray(2110, 2120, EnumSortDirection.Asc);
            var actual = _sortHelper.ExecuteQuick(arr, EnumSortDirection.Asc, EnumSpeed.Slow);
            TestContext.WriteLine($"actual/expected: {actual}");
            Assert.AreEqual(_expectedAsc, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(Quick_Execute_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

	}
}
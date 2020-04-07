// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Diagnostics;
	
namespace GrokkingAlgorithms.Tests.Helpers
{
	[TestFixture]
	public class SortSelectionHelperTests
	{
		private SortSelectionHelper _sortSelectionHelper = SortSelectionHelper.Instance;
		private ArrayHelper _arrayHelper = ArrayHelper.Instance;

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
		public void Execute_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Execute_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			var expectedDesc = new int?[] { 2120, 2119, 2118, 2117, 2116, 2115, 2114, 2113, 2112, 2111, 2110 };
			var expectedAsc = new int?[] { 2110, 2111, 2112, 2113, 2114, 2115, 2116, 2117, 2118, 2119, 2120 };

			var arr = _arrayHelper.GetSortArray(2110, 2120, EnumSort.Asc);
			_sortSelectionHelper.Execute(arr, EnumSort.Desc, EnumAlgorithm.Slow);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(expectedDesc, arr);
			_sortSelectionHelper.Execute(arr, EnumSort.Asc, EnumAlgorithm.Slow);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(expectedAsc, arr);

			_sortSelectionHelper.Execute(arr, EnumSort.Desc, EnumAlgorithm.Middle);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(expectedDesc, arr);
			_sortSelectionHelper.Execute(arr, EnumSort.Asc, EnumAlgorithm.Middle);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(expectedAsc, arr);

			_sortSelectionHelper.Execute(arr, EnumSort.Desc, EnumAlgorithm.Fast);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(expectedDesc, arr);
			_sortSelectionHelper.Execute(arr, EnumSort.Asc, EnumAlgorithm.Fast);
			TestContext.WriteLine($"actual/expected: {arr}");
			Assert.AreEqual(expectedAsc, arr);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
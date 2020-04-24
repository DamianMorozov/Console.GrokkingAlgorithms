// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Lib;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace GrokkingAlgorithms.Lib.Tests
{
	[TestFixture]
	public class BinarySearchHelperTests
	{
		private readonly BinarySearchHelper _binarySearchHelper = BinarySearchHelper.Instance;
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
		public void GetSortArray_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(GetSortArray_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

            // array
			var arr = _arrayHelper.SortArray(1300, 1400, EnumSortDirection.Asc);
			var actual = _binarySearchHelper.Execute(arr, 1313, EnumSortDirection.Asc);
			(int?, int) expected = (13, 7);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			// list
			actual = _binarySearchHelper.Execute(arr.ToList(), 1313, EnumSortDirection.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			arr = _arrayHelper.SortArray(1400, 1300, EnumSortDirection.Desc);
			TestContext.WriteLine("== " + string.Join(", ", arr));
			actual = _binarySearchHelper.Execute(arr, 1313, EnumSortDirection.Desc);
			expected = (87, 7);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			// list
			actual = _binarySearchHelper.Execute(arr.ToList(), 1313, EnumSortDirection.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			actual = _binarySearchHelper.Execute(arr, 2000, EnumSortDirection.Asc);
			expected = (null, 7);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			// list
			actual = _binarySearchHelper.Execute(arr.ToList(), 2000, EnumSortDirection.Asc);
			expected = (null, 7);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			arr = _arrayHelper.SortArray(20100, 22200, EnumSortDirection.Asc);
			actual = _binarySearchHelper.Execute(arr, 21500, EnumSortDirection.Asc);
			expected = (1400, 11);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			// list
			actual = _binarySearchHelper.Execute(arr.ToList(), 21500, EnumSortDirection.Asc);
			expected = (1400, 11);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			// array
			arr = _arrayHelper.SortArray(20100, 22200, EnumSortDirection.Asc);
			actual = _binarySearchHelper.Execute(arr, 1313, EnumSortDirection.Asc);
			expected = (null, 11);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			// list
			actual = _binarySearchHelper.Execute(arr.ToList(), 1313, EnumSortDirection.Asc);
			expected = (null, 11);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(GetSortArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
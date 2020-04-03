// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace GrokkingAlgorithms.Tests.Helpers
{
	[TestFixture]
	public class FirstValueHelperTests
	{
		private FirstValueHelper _firstValueHelper = FirstValueHelper.Instance;
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
		public void ExecuteForeach_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(ExecuteForeach_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			int?[] arr;
			(int pos, int? val) actual;
			(int pos, int? val) expected;

			arr = new int?[0];
			actual = _firstValueHelper.ExecuteForeach(arr, EnumSort.Asc);
			expected = (-1, null);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			arr = _arrayHelper.GetSortArray(1234, 2345, EnumSort.Asc);
			actual = _firstValueHelper.ExecuteForeach(arr, EnumSort.Desc);
			expected = (1111, 2345);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			arr = _arrayHelper.GetSortArray(12345, 12345, EnumSort.Asc);
			actual = _firstValueHelper.ExecuteForeach(arr, EnumSort.Asc);
			expected = (0, 12345);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _firstValueHelper.ExecuteForeach(arr, EnumSort.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			expected = (0, 1234);
			arr = _arrayHelper.GetSortArray(1234, 2345, EnumSort.Asc);
			actual = _firstValueHelper.ExecuteForeach(arr, EnumSort.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _firstValueHelper.ExecuteForeach(arr.ToList(), EnumSort.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			expected = (1111, 2345);
			arr = _arrayHelper.GetSortArray(1234, 2345, EnumSort.Asc);
			actual = _firstValueHelper.ExecuteForeach(arr, EnumSort.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);
			actual = _firstValueHelper.ExecuteForeach(arr.ToList(), EnumSort.Desc);
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

			int?[] arr;
			int? actual;

			arr = _arrayHelper.GetSortArray(1234, 2345, EnumSort.Asc);
			actual = _firstValueHelper.ExecuteRecursive(arr, EnumSort.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(1234, actual);
			actual = _firstValueHelper.ExecuteRecursive(arr, EnumSort.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(2345, actual);
			arr = _arrayHelper.GetSortArray(1234, 2345, EnumSort.Asc);
			actual = _firstValueHelper.ExecuteRecursive(arr.ToList(), EnumSort.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(1234, actual);
			actual = _firstValueHelper.ExecuteRecursive(arr.ToList(), EnumSort.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(2345, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(ExecuteRecursive_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
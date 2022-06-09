// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace GrokkingAlgorithms.Lib.Tests
{
    [TestFixture]
	public class FirstValueHelperTests
	{
		private readonly FirstValueHelper _firstValueHelper = FirstValueHelper.Instance;
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
			Stopwatch sw = Stopwatch.StartNew();

            int?[] arr = new int?[0];
			(int pos, int? val) actual = _firstValueHelper.Execute(arr, EnumSortDirect.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((-1, default(int?)), actual);
			arr = _arrayHelper.SortArray(1234, 2345, EnumSortDirect.Asc);
			actual = _firstValueHelper.Execute(arr, EnumSortDirect.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((1111, 2345), actual);

			arr = _arrayHelper.SortArray(12345, 12345, EnumSortDirect.Asc);
			actual = _firstValueHelper.Execute(arr, EnumSortDirect.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((0, 12345), actual);
			actual = _firstValueHelper.Execute(arr, EnumSortDirect.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((0, 12345), actual);

			arr = _arrayHelper.SortArray(1234, 2345, EnumSortDirect.Asc);
			actual = _firstValueHelper.Execute(arr, EnumSortDirect.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((0, 1234), actual);
			actual = _firstValueHelper.Execute(arr.ToList(), EnumSortDirect.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((0, 1234), actual);

			arr = _arrayHelper.SortArray(1233, 2345, EnumSortDirect.Asc);
			actual = _firstValueHelper.Execute(arr, EnumSortDirect.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((1112, 2345), actual);
			actual = _firstValueHelper.Execute(arr.ToList(), EnumSortDirect.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((1112, 2345), actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_Fast_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}

		[Test]
		public void Execute_Slow_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Execute_Slow_AreEqual)} start.");
			Stopwatch sw = Stopwatch.StartNew();

            int?[] arr = _arrayHelper.SortArray(1233, 2345, EnumSortDirect.Asc);
			(int pos, int? val) actual = _firstValueHelper.Execute(arr, EnumSortDirect.Asc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((0, 1233), actual);
			actual = _firstValueHelper.Execute(arr, EnumSortDirect.Desc);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((1112, 2345), actual);
			arr = _arrayHelper.SortArray(1233, 2345, EnumSortDirect.Asc);
			actual = _firstValueHelper.Execute(arr.ToList(), EnumSortDirect.Asc, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((-1, 1233), actual);
			actual = _firstValueHelper.Execute(arr.ToList(), EnumSortDirect.Desc, EnumSpeed.Slow);
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual((-1, 2345), actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Execute_Slow_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
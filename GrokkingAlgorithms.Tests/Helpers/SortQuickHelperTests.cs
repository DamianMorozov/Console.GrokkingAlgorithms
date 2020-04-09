// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Diagnostics;
using GrokkingAlgorithms.Helpers;

namespace GrokkingAlgorithms.Tests.Helpers
{
	[TestFixture]
	public class SortQuickHelperTests
	{
		private SortQuickHelper _sortQuickHelper = SortQuickHelper.Instance;

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
		public void Foo_AreEqual()
		{
			TestContext.WriteLine(@"--------------------------------------------------------------------------------");
			TestContext.WriteLine($@"{nameof(Foo_AreEqual)} start.");
			var sw = Stopwatch.StartNew();

			int actual = default;
			// 
			int expected = default;
			TestContext.WriteLine($"actual/expected: {actual}");
			Assert.AreEqual(expected, actual);

			sw.Stop();
			TestContext.WriteLine($@"{nameof(Foo_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
		}
	}
}
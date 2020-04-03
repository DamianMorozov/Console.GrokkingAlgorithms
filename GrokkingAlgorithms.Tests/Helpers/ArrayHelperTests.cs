// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Diagnostics;

namespace GrokkingAlgorithms.Tests.Helpers
{
    [TestFixture]
    internal class ArrayHelperTests
    {
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
        public void GetSortArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetSortArray_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var actual = _arrayHelper.GetSortArray(210, 220);
            var expected = new int?[] { 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220 };
            TestContext.WriteLine($"actual/expected: {actual}");
            Assert.AreEqual(expected, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(GetSortArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

        [Test]
        public void GetRandomArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetRandomArray_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var arr = _arrayHelper.GetRandomArray(12_500, 100_000);
            var actual = arr.Length;
            var expected = 12_500;
            TestContext.WriteLine($"actual/expected: {actual}");
            Assert.AreEqual(expected, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(GetRandomArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
        
        [Test]
        public void GetSubArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetSubArray_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var arr = _arrayHelper.GetSortArray(210, 220);
            var actual = _arrayHelper.GetSubArray(arr, 6, 5);
            var expected = new int?[] { 216, 217, 218, 219, 220 };
            TestContext.WriteLine($"actual/expected: {actual}");
            Assert.AreEqual(expected, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(GetSubArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
    }
}

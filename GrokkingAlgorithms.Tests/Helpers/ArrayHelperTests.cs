// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using GrokkingAlgorithms.Helpers;
using NUnit.Framework;
using System.Diagnostics;

namespace GrokkingAlgorithms.Tests.Helpers
{
    [TestFixture]
    public class ArrayHelperTests
    {
        private readonly ArrayHelper _arrayHelper = ArrayHelper.Instance;
        private readonly int?[] _expectedAsc = { 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220 };
        private readonly int?[] _expectedDesc = { 220, 219, 218, 217, 216, 215, 214, 213, 212, 211, 210 };

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

            var actual = _arrayHelper.GetSortArray(210, 220, EnumSortDirection.Asc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedAsc, actual);

            actual = _arrayHelper.GetSortArray(220, 210, EnumSortDirection.Desc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedDesc, actual);

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
            TestContext.WriteLine($"actual/expected: {arr.Length}");
            Assert.AreEqual(12_500, arr.Length);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(GetRandomArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
        
        [Test]
        public void GetSubArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetSubArray_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var arr = _arrayHelper.GetSortArray(210, 220, EnumSortDirection.Asc);
            var actual = _arrayHelper.GetSubArray(arr, 6, 5);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(new int?[] { 216, 217, 218, 219, 220 }, actual);

            arr = _arrayHelper.GetSortArray(220, 210, EnumSortDirection.Desc);
            actual = _arrayHelper.GetSubArray(arr, 6, 5);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(new int?[] { 214, 213, 212, 211, 210 }, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(GetSubArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

        [Test]
        public void GetCopyArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetCopyArray_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var arr = _arrayHelper.GetSortArray(210, 220, EnumSortDirection.Asc);
            var actual = _arrayHelper.GetCopyArray(arr);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedAsc, actual);

            arr = _arrayHelper.GetSortArray(220, 210, EnumSortDirection.Desc);
            actual = _arrayHelper.GetCopyArray(arr);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedDesc, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(GetCopyArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
    }
}

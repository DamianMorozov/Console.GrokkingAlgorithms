// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Diagnostics;

namespace GrokkingAlgorithms.Lib.Tests
{
    [TestFixture]
    public class ArrayHelperTests
    {
        private readonly ArrayHelper _arrayHelper = ArrayHelper.Instance;
        private readonly int?[] _expectedAsc = { 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220 };
        private readonly int?[] _expectedDesc = { 220, 219, 218, 217, 216, 215, 214, 213, 212, 211, 210 };
        private readonly int?[] _expectedSubAsc = { 214, 213, 212, 211, 210 };
        private readonly int?[] _expectedSubDesc = { 216, 217, 218, 219, 220 };

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
        public void SortArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SortArray_AreEqual)} start.");
            Stopwatch sw = Stopwatch.StartNew();

            int?[] actual = _arrayHelper.SortArray(210, 220, EnumSortDirect.Asc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedAsc, actual);

            actual = _arrayHelper.SortArray(220, 210, EnumSortDirect.Desc);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedDesc, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(SortArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

        [Test]
        public void RandomArray_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(RandomArray_AreEqual)} start.");
            Stopwatch sw = Stopwatch.StartNew();

            int?[] arr = _arrayHelper.RandomArray(12_500, 100_000);
            TestContext.WriteLine($"actual/expected: {arr.Length}");
            Assert.AreEqual(12_500, arr.Length);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(RandomArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
        
        //[Test]
        //public void SubArray_AreEqual()
        //{
        //    TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        //    TestContext.WriteLine($@"{nameof(SubArray_AreEqual)} start.");
        //    var sw = Stopwatch.StartNew();

        //    var arr = _arrayHelper.SortArray(210, 220, EnumSortDirection.Asc);
        //    var actual = _arrayHelper.SubArray(arr, 6, 5);
        //    TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
        //    Assert.AreEqual(_expectedSubDesc, actual);

        //    arr = _arrayHelper.SortArray(220, 210, EnumSortDirection.Desc);
        //    actual = _arrayHelper.SubArray(arr, 6, 5);
        //    TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
        //    Assert.AreEqual(_expectedSubAsc, actual);

        //    sw.Stop();
        //    TestContext.WriteLine($@"{nameof(SubArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        //}
        
        [Test]
        public void Sub_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Sub_AreEqual)} start.");
            Stopwatch sw = Stopwatch.StartNew();

            int?[] arr = _arrayHelper.SortArray(210, 220, EnumSortDirect.Asc);
            int?[] actual = _arrayHelper.Sub(arr, 6, 5);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedSubDesc, actual);

            arr = _arrayHelper.SortArray(220, 210, EnumSortDirect.Desc);
            actual = _arrayHelper.Sub(arr, 6, 5);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedSubAsc, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(Sub_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }

        //[Test]
        //public void CopyArray_AreEqual()
        //{
        //    TestContext.WriteLine(@"--------------------------------------------------------------------------------");
        //    TestContext.WriteLine($@"{nameof(CopyArray_AreEqual)} start.");
        //    var sw = Stopwatch.StartNew();

        //    var arr = _arrayHelper.SortArray(210, 220, EnumSortDirection.Asc);
        //    var actual = _arrayHelper.CopyArray(arr);
        //    TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
        //    Assert.AreEqual(_expectedAsc, actual);

        //    arr = _arrayHelper.SortArray(220, 210, EnumSortDirection.Desc);
        //    actual = _arrayHelper.CopyArray(arr);
        //    TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
        //    Assert.AreEqual(_expectedDesc, actual);

        //    sw.Stop();
        //    TestContext.WriteLine($@"{nameof(CopyArray_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        //}

        [Test]
        public void Copy_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(Copy_AreEqual)} start.");
            Stopwatch sw = Stopwatch.StartNew();

            int?[] arr = _arrayHelper.SortArray(210, 220, EnumSortDirect.Asc);
            int?[] actual = _arrayHelper.Copy(arr);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedAsc, actual);

            arr = _arrayHelper.SortArray(220, 210, EnumSortDirect.Desc);
            actual = _arrayHelper.Copy(arr);
            TestContext.WriteLine($"actual/expected: {string.Join(", ", actual)}");
            Assert.AreEqual(_expectedDesc, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(Copy_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
    }
}

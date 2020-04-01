// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Diagnostics;

namespace GrokkingAlgorithms.Tests
{
    [TestFixture]
    public class ProgramTests
    {
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
        public void SetValue_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetValue_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var defValue = 111;
            int actual = default;
            Program.SetValue("123", ref actual, defValue);
            TestContext.WriteLine($"actual: {actual}");
            var expected = 123;
            TestContext.WriteLine($"expected: {expected}");
            Assert.AreEqual(expected, actual);

            actual = default;
            Program.SetValue("12s3", ref actual, defValue);
            TestContext.WriteLine($"actual: {actual}");
            expected = defValue;
            TestContext.WriteLine($"expected: {expected}");
            Assert.AreEqual(expected, actual);

            actual = default;
            Program.SetValue(string.Empty, ref actual, defValue);
            TestContext.WriteLine($"actual: {actual}");
            expected = defValue;
            TestContext.WriteLine($"expected: {expected}");
            Assert.AreEqual(expected, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(SetValue_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
        
        [Test]
        public void SetValueSafe_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(SetValueSafe_AreEqual)} start.");
            var sw = Stopwatch.StartNew();

            var defValue = 111;
            int actual = default;
            Program.SetValueSafe("123", ref actual, defValue);
            TestContext.WriteLine($"actual: {actual}");
            var expected = 123;
            TestContext.WriteLine($"expected: {expected}");
            Assert.AreEqual(expected, actual);

            actual = default;
            Program.SetValueSafe("12s3", ref actual, defValue);
            TestContext.WriteLine($"actual: {actual}");
            TestContext.WriteLine($"expected: {defValue}");
            Assert.AreEqual(defValue, actual);

            actual = default;
            Program.SetValueSafe(string.Empty, ref actual, defValue);
            TestContext.WriteLine($"actual: {actual}");
            TestContext.WriteLine($"expected: {defValue}");
            Assert.AreEqual(defValue, actual);

            sw.Stop();
            TestContext.WriteLine($@"{nameof(SetValue_AreEqual)} complete. Elapsed time: {sw.Elapsed}");
        }
    }
}

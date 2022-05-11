// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using NUnit.Framework;
using System.Reflection;

namespace GrokkingAlgorithms.Lib.Tests
{
    [TestFixture]
    public class FileHelperTests
    {
        private readonly FileHelper _fileHelper = FileHelper.Instance;

        [Test]
        public void GetWriteFileName_AreEqual()
        {
            TestContext.WriteLine(@"--------------------------------------------------------------------------------");
            TestContext.WriteLine($@"{nameof(GetWriteFileName_AreEqual)} start.");
            Assert.DoesNotThrow(() => {
                string fileRead = Assembly.GetExecutingAssembly().Location;
                TestContext.WriteLine($"{nameof(fileRead)}: {fileRead}");
                string fileWrite = _fileHelper.GetOutFileName(fileRead, "_result");
                TestContext.WriteLine($"{nameof(fileWrite)}: {fileWrite}");
            });
        }
    }
}

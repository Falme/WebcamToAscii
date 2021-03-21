using ImageToAscii;
using NUnit.Framework;

namespace ImageToAsciiTest
{
    public class ReadPNGIDataTests
    {
        ReadPNGIData readPNGIData;

        [SetUp]
        public void Setup()
        {
            readPNGIData = new ReadPNGIData();
        }

        [Test]
        [TestCase(".", new byte[] { 73, 68, 65, 84, 120, 156, 99,  80, 0, 0, 0,  34, 0,  33, 227, 239, 103,  11, 0, 0, 0, 0 } )]
        [TestCase("@", new byte[] { 73, 68, 65, 84, 120, 156, 99, 152, 1, 0, 0, 154, 0, 153, 217, 182, 241,  84, 0, 0, 0, 0 })]
        //[TestCase("@.", new byte[]{ 73, 68, 65, 84, 120, 156, 99, 152, 0, 0, 0, 146, 0, 145,  18,  34, 251, 123, 0, 0, 0, 0 })]
        //[TestCase(".@", new byte[]{ 73, 68, 65, 84, 120, 156, 99, 136, 0, 0, 0,  90, 0,  89, 127, 255, 234, 207, 0, 0, 0, 0 })]
        public void ConvertDataToAscii_OneCharResult(string expected, byte[] bytesIData)
        {
            string asciiResult = readPNGIData.ConvertDataToAscii(bytesIData);

            Assert.AreEqual(expected, asciiResult);
        }
    }
}
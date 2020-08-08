using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string CSVFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
        static string invalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        CensorAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensorAnalyser();
        }

        [Test]
        public void Test1()
        {
            string[] actual = censusAnalyser.LoadIndianCensusCSVData(CSVFilePath);
            Assert.AreEqual(29, actual.Length);
        }

        [Test]
        public void Test2()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(invalidFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.type);
            }
        }

    }
}
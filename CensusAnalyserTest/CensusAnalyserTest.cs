using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string CSVFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        static string InvalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\CensorAnalyser.cs";
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
                censusAnalyser.LoadIndianCensusCSVData(InvalidFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, ex.type);
            }
        }

        [Test]
        public void Test3()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidCSVTypeFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, ex.type);
            }
        }

    }
}
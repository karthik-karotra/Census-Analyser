using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string CSVFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
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



    }
}
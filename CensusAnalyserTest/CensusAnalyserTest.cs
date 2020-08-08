using CensusAnalyser;
using NUnit.Framework;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string CSVFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        static string InvalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\CensorAnalyser.cs";
        static string InvalidDeliminatorFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectDeliminatorCensusFile.csv";
        static string InvalidHeaderFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectHeaderCensusFile.csv";
        CensorAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensorAnalyser();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            string[] actual = censusAnalyser.LoadIndianCensusCSVData(CSVFilePath);
            Assert.AreEqual(29, actual.Length);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
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
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
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

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidDeliminatorFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, ex.type);
            }
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            try
            {
                censusAnalyser.LoadIndianCensusCSVData(InvalidHeaderFilePath);
            }
            catch (CensusAnalyserException ex)
            {
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, ex.type);
            }
        }

    }
}
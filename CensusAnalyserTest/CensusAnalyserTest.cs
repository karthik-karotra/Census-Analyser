using CensusAnalyser;
using NUnit.Framework;
using static CensusAnalyser.CensorAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string CSVFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
        static string InvalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        static string InvalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\CensorAnalyser.cs";
        static string InvalidDeliminatorFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectDeliminatorCensusFile.csv";
        static string InvalidHeaderFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectHeaderCensusFile.csv";
        static string CSVStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCode.csv";
        static string InvalidDeliminatorStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\InvalidDeliminatorIndiaStateCode.csv";
        static string StateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string StateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";
        CensorAnalyser censusAnalyser;
        CSVFileData csvFileData;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            censusAnalyser = new CensorAnalyser(CSVFilePath, StateCensusFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            string[] totalNumberOfRecords = (string[])csvFileData();
            Assert.AreEqual(29, totalNumberOfRecords.Length);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidFilePath, StateCensusFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidCSVTypeFilePath, StateCensusFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidDeliminatorFilePath, StateCensusFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidHeaderFilePath, StateCensusFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            censusAnalyser = new CensorAnalyser(CSVStateCodeFilePath, StateCodeFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            string[] totalNumberOfRecords = (string[])csvFileData();
            Assert.AreEqual(37, totalNumberOfRecords.Length);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidFilePath, StateCodeFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidCSVTypeFilePath, StateCodeFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidDeliminatorStateCodeFilePath, StateCodeFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            censusAnalyser = new CensorAnalyser(InvalidHeaderFilePath, StateCodeFileHeaders);
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData());
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }
    }
}
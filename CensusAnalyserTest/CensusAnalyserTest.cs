using CensusAnalyser;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
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
        CSVFileData csvFileData;
        CSVFactory csvFactory;
        List<string> totalNumberOfRecords;

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalNumberOfRecords = new List<string>();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (List<string>)csvFileData(CSVFilePath, StateCensusFileHeaders);
            Assert.AreEqual(29, totalNumberOfRecords.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidFilePath, StateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidCSVTypeFilePath, StateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidDeliminatorFilePath, StateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidHeaderFilePath, StateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (List<string>)csvFileData(CSVStateCodeFilePath, StateCodeFileHeaders);
            Assert.AreEqual(37, totalNumberOfRecords.Count);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidFilePath, StateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidCSVTypeFilePath, StateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidDeliminatorStateCodeFilePath, StateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.getCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(InvalidHeaderFilePath, StateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenProper_ShouldReturnSortedDataAccordungToStatesInJSONFormat()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.getSortedCSVDataInJsonFormat(CSVFilePath,0).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh,49386799,162968,303", sortedIndianCensusData[0]);
        }

        [Test]
        public void GivenIndianStateCSVFile_WhenProper_ShouldReturnSortedDataAccordingToStateCodeInJSONFormats()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.getSortedCSVDataInJsonFormat(CSVStateCodeFilePath, 3).ToString();
            string[] sortedStateCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("3,Andhra Pradesh New,37,AD", sortedStateCensusData[0]);
        }
    }
}
using CensusAnalyser;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyser.CensorAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static readonly string csvFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
        static readonly string invalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        static readonly string invalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\CensorAnalyser.cs";
        static readonly string invalidDeliminatorFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectDeliminatorCensusFile.csv";
        static readonly string invalidHeaderFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectHeaderCensusFile.csv";
        static readonly string csvStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCode.csv";
        static readonly string invalidDeliminatorStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\InvalidDeliminatorIndiaStateCode.csv";
        static readonly string stateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string stateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";
        CSVFileData csvFileData;
        CSVFactory csvFactory;
        Dictionary<int, string> totalNumberOfRecords;
        Dictionary<int, string> totalRecords;

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalNumberOfRecords = new Dictionary<int, string>();
            totalRecords = new Dictionary<int, string>();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (Dictionary<int, string>)csvFileData(csvFilePath, stateCensusFileHeaders);
            Assert.AreEqual(29, totalNumberOfRecords.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidFilePath, stateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidCSVTypeFilePath, stateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidDeliminatorFilePath, stateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidHeaderFilePath, stateCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (Dictionary<int, string>)csvFileData(csvStateCodeFilePath, stateCodeFileHeaders);
            totalRecords = (Dictionary<int, string>)csvFileData(csvFilePath, stateCensusFileHeaders);
            Assert.AreEqual(37, totalNumberOfRecords.Count);
            Assert.AreEqual(29, totalRecords.Count);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidFilePath, stateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidCSVTypeFilePath, stateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidDeliminatorStateCodeFilePath, stateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidHeaderFilePath, stateCodeFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders,0).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh,49386799,162968,303", sortedIndianCensusData[0]);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfUttarakhandState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, 0).ToString();
            string[] sortedIndianCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("West Bengal,91347736,88752,1029", sortedIndianCensusData[sortedIndianCensusData.Length-1]);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvStateCodeFilePath, stateCodeFileHeaders, 3).ToString();
            string[] sortedStateCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("3,Andhra Pradesh New,37,AD", sortedStateCensusData[0]);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfWestBengalState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvStateCodeFilePath, stateCodeFileHeaders, 3).ToString();
            string[] sortedStateCensusData = JsonConvert.DeserializeObject<string[]>(sortedData);
            Assert.AreEqual("37,West Bengal,19,WB", sortedStateCensusData[sortedStateCensusData.Length-1]);
        }
    }
}
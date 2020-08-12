using CensusAnalyser;
using CensusAnalyser.DAO;
using CensusAnalyser.POCO;
using CensusAnalyser.SortAttributes;
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
        Dictionary<string, IndianCensusDAO> totalNumberOfRecords;

        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalNumberOfRecords = new Dictionary<string,IndianCensusDAO>();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfRecords = (Dictionary<string,IndianCensusDAO>)csvFileData(csvFilePath, stateCensusFileHeaders);
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
            totalNumberOfRecords = (Dictionary<string,IndianCensusDAO>)csvFileData(csvStateCodeFilePath, stateCodeFileHeaders);
            Assert.AreEqual(37, totalNumberOfRecords.Count);
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
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfUttarakhandState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("West Bengal", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvStateCodeFilePath, stateCodeFileHeaders, SortType.SortBy.STATE_CODE_ASCENDING).ToString();
            IndianStateCode[] sortedStateCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("AD", sortedStateCensusData[0].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfWestBengalState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvStateCodeFilePath, stateCodeFileHeaders, SortType.SortBy.STATE_CODE_ASCENDING).ToString();
            IndianStateCode[] sortedStateCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("WB", sortedStateCensusData[sortedStateCensusData.Length - 1].stateCode);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsMostPopulousState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsLeastPopulousState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Sikkim", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsMostDenselyPopulatedState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsLeastDenseleyPopulatedState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }
    }
}
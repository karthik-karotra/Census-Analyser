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
        static readonly string csvIndainCensusFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCensusData.csv";
        static readonly string invalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        static readonly string invalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\CensorAnalyser.cs";
        static readonly string invalidDeliminatorFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectDeliminatorCensusFile.csv";
        static readonly string invalidHeaderFilePath = @"D:\C-Sharp\CensusAnalyser\IncorrectHeaderCensusFile.csv";
        static readonly string csvStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCode.csv";
        static readonly string invalidDeliminatorStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\InvalidDeliminatorIndiaStateCode.csv";
        static readonly string stateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string stateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";
        static readonly string usCSVFilePath = @"D:\C-Sharp\CensusAnalyser\USCensusData .csv";
        static readonly string invalidDeliminatorUSCensusFilePath = @"D:\C-Sharp\CensusAnalyser\InvalidDeliminatorUSCensusData.csv";
        static readonly string usCensusFileHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        CSVFileData csvFileData;
        CSVFactory csvFactory;
        Dictionary<string, IndianCensusDAO> totalNumberOfIndianCensusRecords;
        Dictionary<string, USCensusDAO> totalNumberOfUSCensusRecords;


        [SetUp]
        public void Setup()
        {
            csvFactory = new CSVFactory();
            totalNumberOfIndianCensusRecords = new Dictionary<string,IndianCensusDAO>();
            totalNumberOfUSCensusRecords = new Dictionary<string, USCensusDAO>();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadCSVFileData);
            totalNumberOfIndianCensusRecords = (Dictionary<string,IndianCensusDAO>)csvFileData(csvIndainCensusFilePath, stateCensusFileHeaders);
            Assert.AreEqual(29, totalNumberOfIndianCensusRecords.Count);
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
            totalNumberOfIndianCensusRecords = (Dictionary<string,IndianCensusDAO>)csvFileData(csvStateCodeFilePath, stateCodeFileHeaders);
            Assert.AreEqual(37, totalNumberOfIndianCensusRecords.Count);
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
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfUttarakhandState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING).ToString();
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
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsLeastPopulousState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Sikkim", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsMostDenselyPopulatedState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsLeastDenseleyPopulatedState()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsLargestStateByArea()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Rajasthan", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnsSmallestStateByArea()
        {
            CensorAnalyser censusAnalyser = new CensorAnalyser();
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvIndainCensusFilePath, stateCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING).ToString();
            IndianStateCode[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("Goa", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadUSCSVFileData);
            totalNumberOfUSCensusRecords = (Dictionary<string, USCensusDAO>)csvFileData(usCSVFilePath, usCensusFileHeaders);
            Assert.AreEqual(51, totalNumberOfUSCensusRecords.Count);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadUSCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidFilePath, usCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadUSCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidCSVTypeFilePath, usCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadUSCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidDeliminatorUSCensusFilePath, usCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            CensorAnalyser censusAnalyser = (CensorAnalyser)csvFactory.GetCensusAnalyser();
            csvFileData = new CSVFileData(censusAnalyser.LoadUSCSVFileData);
            var exception = Assert.Throws<CensusAnalyserException>(() => csvFileData(invalidHeaderFilePath, usCensusFileHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

    }
}
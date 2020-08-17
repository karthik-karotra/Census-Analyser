// <copyright file="CensusAnalyserTest.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyserTest
{
    using System.Collections.Generic;
    using CensusAnalyser;
    using CensusAnalyser.POCO;
    using CensusAnalyser.SortAttributes;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using static CensusAnalyser.CensusAnalyser;

    /// <summary>
    /// Test Class.
    /// </summary>
    public class CensusAnalyserTest
    {
        private readonly string indianCensusCSVFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IndiaStateCensusData.csv";
        private readonly string invalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        private readonly string invalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\Service\CensusAnalyser.cs";
        private readonly string invalidDeliminatorFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IncorrectDeliminatorCensusFile.csv";
        private readonly string invalidHeaderFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IncorrectHeaderCensusFile.csv";
        private readonly string csvStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IndiaStateCode.csv";
        private readonly string invalidDeliminatorStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\InvalidDeliminatorIndiaStateCode.csv";
        private readonly string stateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        private readonly string stateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";
        private readonly string usCSVFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\USCensusData .csv";
        private readonly string invalidDeliminatorUSCensusFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\InvalidDeliminatorUSCensusData.csv";
        private readonly string usCensusFileHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        private Dictionary<string, dynamic> totalRecords;
        private CensusAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            this.censusAnalyser = new CensusAnalyser();
            this.totalRecords = new Dictionary<string, dynamic>();
        }

        // Indian Census CSV File
        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            this.totalRecords = this.censusAnalyser.LoadCSVFileData(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, Country.INDIA);
            Assert.AreEqual(29, this.totalRecords.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidFilePath, this.stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidCSVTypeFilePath, this.stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidDeliminatorFilePath, this.stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidHeaderFilePath, this.stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        // Indian State CSV File
        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            this.totalRecords = this.censusAnalyser.LoadCSVFileData(this.csvStateCodeFilePath, this.stateCodeFileHeaders, Country.INDIA);
            Assert.AreEqual(37, this.totalRecords.Count);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidFilePath, this.stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidCSVTypeFilePath, this.stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidDeliminatorStateCodeFilePath, this.stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidHeaderFilePath, this.stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        // Sorting Of Both Indian CSV Files
        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianCensusData[0].State);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfUttarakhandState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("West Bengal", sortedIndianCensusData[sortedIndianCensusData.Length - 1].State);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.csvStateCodeFilePath, this.stateCodeFileHeaders, SortType.SortBy.STATE_CODE_ASCENDING, Country.INDIA).ToString();
            IndianStateCode[] sortedStateCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("AD", sortedStateCensusData[0].StateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfWestBengalState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.csvStateCodeFilePath, this.stateCodeFileHeaders, SortType.SortBy.STATE_CODE_ASCENDING, Country.INDIA).ToString();
            IndianStateCode[] sortedStateCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("WB", sortedStateCensusData[sortedStateCensusData.Length - 1].StateCode);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostPopulousState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianCensusData[0].State);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastPopulousState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Sikkim", sortedIndianCensusData[sortedIndianCensusData.Length - 1].State);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostDenselyPopulatedState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianCensusData[0].State);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastDenselyPopulatedState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedIndianCensusData[sortedIndianCensusData.Length - 1].State);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLargestStateByArea()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Rajasthan", sortedIndianCensusData[0].State);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnSmallestStateByArea()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Goa", sortedIndianCensusData[sortedIndianCensusData.Length - 1].State);
        }

        // US Census CSV File
        [Test]
        public void GivenUSCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            this.totalRecords = this.censusAnalyser.LoadCSVFileData(this.usCSVFilePath, this.usCensusFileHeaders, Country.US);
            Assert.AreEqual(51, this.totalRecords.Count);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidFilePath, this.usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidCSVTypeFilePath, this.usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidDeliminatorUSCensusFilePath, this.usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => this.censusAnalyser.LoadCSVFileData(this.invalidHeaderFilePath, this.usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        // Sorting Of US Census File
        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostPopulousState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("California", sortedUSCensusData[0].State);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastPopulousState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("Wyoming", sortedUSCensusData[sortedUSCensusData.Length - 1].State);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostDenselyPopulatedState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("District of Columbia", sortedUSCensusData[0].State);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastDenselyPopulatedState()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("Alaska", sortedUSCensusData[sortedUSCensusData.Length - 1].State);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLargestStateByArea()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("Alaska", sortedUSCensusData[0].State);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnSmallestStateByArea()
        {
            string sortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("District of Columbia", sortedUSCensusData[sortedUSCensusData.Length - 1].State);
        }

        [Test]
        public void GivenIndiaAndUSCensusCSVFiles_WhenFilesPresent_ShouldReturnMostPopulousStateWithDensity()
        {
            string indianCSVFileSortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.indianCensusCSVFilePath, this.stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(indianCSVFileSortedData);
            string usCSVFileSortedData = this.censusAnalyser.GetSortedCSVDataInJsonFormat(this.usCSVFilePath, this.usCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(usCSVFileSortedData);
            string mostDenselyPopulatedState = this.censusAnalyser.GetMostPopulousStateWithDensity(sortedIndianCensusData[0], sortedUSCensusData[0]);
            Assert.AreEqual("District of Columbia", mostDenselyPopulatedState);
        }
    }
}
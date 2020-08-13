using CensusAnalyser;
using CensusAnalyser.POCO;
using CensusAnalyser.SortAttributes;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static readonly string indianCensusCSVFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IndiaStateCensusData.csv";
        static readonly string invalidFilePath = @"D:\C-Sharp\IndiaStateCensusData.csv";
        static readonly string invalidCSVTypeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyser\Service\CensusAnalyser.cs";
        static readonly string invalidDeliminatorFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IncorrectDeliminatorCensusFile.csv";
        static readonly string invalidHeaderFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IncorrectHeaderCensusFile.csv";
        static readonly string csvStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\IndiaStateCode.csv";
        static readonly string invalidDeliminatorStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\InvalidDeliminatorIndiaStateCode.csv";
        static readonly string stateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static readonly string stateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";
        static readonly string usCSVFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\USCensusData .csv";
        static readonly string invalidDeliminatorUSCensusFilePath = @"D:\C-Sharp\CensusAnalyser\CensusAnalyserTest\Resources\InvalidDeliminatorUSCensusData.csv";
        static readonly string usCensusFileHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";

        Dictionary<string, dynamic> totalRecords;
        CensusAnalyser.CensusAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser.CensusAnalyser();
            totalRecords = new Dictionary<string, dynamic>();
        }

        //Indian Census CSV File
        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            totalRecords = censusAnalyser.LoadCSVFileData(indianCensusCSVFilePath, stateCensusFileHeaders, Country.INDIA);
            Assert.AreEqual(29, totalRecords.Count);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidFilePath, stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidCSVTypeFilePath, stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidDeliminatorFilePath, stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidHeaderFilePath, stateCensusFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        //Indian State CSV File
        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            totalRecords = censusAnalyser.LoadCSVFileData(csvStateCodeFilePath, stateCodeFileHeaders, Country.INDIA);
            Assert.AreEqual(37, totalRecords.Count);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidFilePath, stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidCSVTypeFilePath, stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidDeliminatorStateCodeFilePath, stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidHeaderFilePath, stateCodeFileHeaders, Country.INDIA));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        //Sorting Of Both Indian CSV Files
        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Andhra Pradesh", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfUttarakhandState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.STATE_ASCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("West Bengal", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnFirstRecordOfAndhraPradeshState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvStateCodeFilePath, stateCodeFileHeaders, SortType.SortBy.STATE_CODE_ASCENDING, Country.INDIA).ToString();
            IndianStateCode[] sortedStateCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("AD", sortedStateCensusData[0].stateCode);
        }

        [Test]
        public void GivenIndianStateCodeCSVFileForSorting_WhenFilePresent_ShouldReturnLastRecordOfWestBengalState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(csvStateCodeFilePath, stateCodeFileHeaders, SortType.SortBy.STATE_CODE_ASCENDING, Country.INDIA).ToString();
            IndianStateCode[] sortedStateCensusData = JsonConvert.DeserializeObject<IndianStateCode[]>(sortedData);
            Assert.AreEqual("WB", sortedStateCensusData[sortedStateCensusData.Length - 1].stateCode);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostPopulousState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Uttar Pradesh", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastPopulousState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Sikkim", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostDenselyPopulatedState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Bihar", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastDenselyPopulatedState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Arunachal Pradesh", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLargestStateByArea()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Rajasthan", sortedIndianCensusData[0].state);
        }

        [Test]
        public void GivenIndianCensusCSVFileForSorting_WhenFilePresent_ShouldReturnSmallestStateByArea()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(sortedData);
            Assert.AreEqual("Goa", sortedIndianCensusData[sortedIndianCensusData.Length - 1].state);
        }

        //US Census CSV File
        [Test]
        public void GivenUSCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            totalRecords = censusAnalyser.LoadCSVFileData(usCSVFilePath, usCensusFileHeaders, Country.US);
            Assert.AreEqual(51, totalRecords.Count);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidFilePath, usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidCSVTypeFilePath, usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidDeliminatorUSCensusFilePath, usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenUSCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
            var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCSVFileData(invalidHeaderFilePath, usCensusFileHeaders, Country.US));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        //Sorting Of US Census File
        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostPopulousState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("California", sortedUSCensusData[0].state);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastPopulousState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.POPULATION_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("Wyoming", sortedUSCensusData[sortedUSCensusData.Length - 1].state);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnMostDenselyPopulatedState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("District of Columbia", sortedUSCensusData[0].state);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLeastDenselyPopulatedState()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("Alaska", sortedUSCensusData[sortedUSCensusData.Length - 1].state);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnLargestStateByArea()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("Alaska", sortedUSCensusData[0].state);
        }

        [Test]
        public void GivenUSCensusCSVFileForSorting_WhenFilePresent_ShouldReturnSmallestStateByArea()
        {
            string sortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.AREA_PER_SQ_KM_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(sortedData);
            Assert.AreEqual("District of Columbia", sortedUSCensusData[sortedUSCensusData.Length - 1].state);
        }

        [Test]
        public void GivenIndiaAndUSCensusCSVFiles_WhenFilesPresent_ShouldReturnMostPopulousStateWithDensity()
        {
            string indianCSVFileSortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(indianCensusCSVFilePath, stateCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.INDIA).ToString();
            IndianCensus[] sortedIndianCensusData = JsonConvert.DeserializeObject<IndianCensus[]>(indianCSVFileSortedData);
            string usCSVFileSortedData = censusAnalyser.GetSortedCSVDataInJsonFormat(usCSVFilePath, usCensusFileHeaders, SortType.SortBy.POPULATION_DENSITY_DESCENDING, Country.US).ToString();
            USCensus[] sortedUSCensusData = JsonConvert.DeserializeObject<USCensus[]>(usCSVFileSortedData);
            string mostDenselyPopulatedState = censusAnalyser.GetMostPopulousStateWithDensity(sortedIndianCensusData[0], sortedUSCensusData[0]);
            Assert.AreEqual("District of Columbia", mostDenselyPopulatedState);
        }
    }
}
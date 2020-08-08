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
        static string CSVStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\IndiaStateCode.csv";
        static string InvalidDeliminatorStateCodeFilePath = @"D:\C-Sharp\CensusAnalyser\InvalidDeliminatorIndiaStateCode.csv";
        static string StateCensusFileHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string StateCodeFileHeaders = "SrNo,State Name,TIN,StateCode";
        CensorAnalyser censusAnalyser;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensorAnalyser();
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            string[] actual = censusAnalyser.LoadIndianCensusCSVData(CSVFilePath, StateCensusFileHeaders);
            Assert.AreEqual(29, actual.Length);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenFileNotFound_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadIndianCensusCSVData(InvalidFilePath, StateCensusFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadIndianCensusCSVData(InvalidCSVTypeFilePath, StateCensusFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadIndianCensusCSVData(InvalidDeliminatorFilePath, StateCensusFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenIndianCensusCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() =>censusAnalyser.LoadIndianCensusCSVData(InvalidHeaderFilePath, StateCensusFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }

        [Test]
        public void GivenStateCensusCSVFile_WhenCorrectFile_ShouldReturnCorrectNoOfRecords()
        {
            string[] actual = censusAnalyser.LoadIndianCensusCSVData(CSVStateCodeFilePath, StateCodeFileHeaders);
            Assert.AreEqual(37, actual.Length);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenFileNotFound_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() =>censusAnalyser.LoadIndianCensusCSVData(InvalidFilePath, StateCodeFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectFileType_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() =>censusAnalyser.LoadIndianCensusCSVData(InvalidCSVTypeFilePath, StateCodeFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectDeliminatorInFile_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() =>censusAnalyser.LoadIndianCensusCSVData(InvalidDeliminatorStateCodeFilePath, StateCodeFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, exception.type);
        }

        [Test]
        public void GivenStateCodesCSVFile_WhenIncorrectHeadersInFile_ShouldThrowException()
        {
                var exception = Assert.Throws<CensusAnalyserException>(() =>censusAnalyser.LoadIndianCensusCSVData(InvalidHeaderFilePath, StateCodeFileHeaders));
                Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, exception.type);
        }
    }
}
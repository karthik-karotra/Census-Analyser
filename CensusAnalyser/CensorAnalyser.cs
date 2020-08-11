using CensusAnalyser.DAO;
using CensusAnalyser.POCO;
using CensusAnalyser.SortAttributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static CensusAnalyser.SortAttributes.SortType;

namespace CensusAnalyser
{
    public class CensorAnalyser : ICSVBuilder
    {

        public delegate object CSVFileData(string csvFilePath, string fileHeaders);
        string[] censusData;
        private Dictionary<string, IndianCensusDAO> CensusDataMap;

        public object LoadCSVFileData(string csvFilePath, string fileHeaders)
        {
            CensusDataMap = new Dictionary<string, IndianCensusDAO>();
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect Type", CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            if (censusData[0] != fileHeaders)
            {
                throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
            }
            foreach (string data in censusData.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    CensusDataMap.Add(column[1], new IndianCensusDAO(new IndianStateCode(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    CensusDataMap.Add(column[0], new IndianCensusDAO(new IndianCensus(column[0], column[1], column[2], column[3])));
            }
            return CensusDataMap;
        }

        public object GetSortedCSVDataInJsonFormat(string csvFilePath, string fileHeaders, SortBy sortType)
        {
            var censusData = (Dictionary<string, IndianCensusDAO>)LoadCSVFileData(csvFilePath, fileHeaders);
            List<IndianCensusDAO> censusDataList = censusData.Values.ToList();
            List<IndianCensusDAO> sortedList = SortType.SortIndianCensusData(censusDataList, sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}
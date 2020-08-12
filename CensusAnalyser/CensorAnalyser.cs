using CensusAnalyser.SortAttributes;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using static CensusAnalyser.SortAttributes.SortType;

namespace CensusAnalyser
{
    public class CensorAnalyser
    {
        public enum Country
        {
            INDIA, US
        }

        public Dictionary<string, dynamic> LoadCSVFileData(string csvFilePath, string fileHeaders, Country country)
        {
            return CensusAdapterFactory.LoadCsvData(csvFilePath, fileHeaders, country);
        }

        public object GetSortedCSVDataInJsonFormat(string csvFilePath, string fileHeaders, SortBy sortType, Country country)
        {
            var censusData = LoadCSVFileData(csvFilePath, fileHeaders, country);
            List<dynamic> sortedList = SortType.SortIndianCensusData(censusData.Values.ToList(), sortType);
            return JsonConvert.SerializeObject(sortedList);
        }
    }
}
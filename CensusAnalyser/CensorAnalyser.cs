using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensorAnalyser : ICSVBuilder
    {

        public delegate object CSVFileData(string csvFilePath, string fileHeaders);
        string[] censusData;
        int keyCounter = 0;
        private readonly Dictionary<int, string> CensusDataMap = new Dictionary<int, string>();

        public object LoadCSVFileData(string csvFilePath, string fileHeaders)
        {
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
            foreach (string data in censusData)
            {
                keyCounter++;
                CensusDataMap.Add(keyCounter, data);
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }
            return CensusDataMap.Skip(1).ToDictionary(p => p.Key, p => p.Value);
        }

        public object GetSortedCSVDataInJsonFormat(string csvFilePath, string fileHeaders,int columnIndex)
        {
            Dictionary<int, string> censusData = (Dictionary<int, string>)LoadCSVFileData(csvFilePath, fileHeaders);
            string[] allRecords = censusData.Values.ToArray();
            var sorted =
                from singleRecord in allRecords
                let column = singleRecord.Split(',')
                orderby column[columnIndex]
                select singleRecord;
            List<string> sortedData = sorted.ToList();
            return JsonConvert.SerializeObject(sortedData);
        }
    }
}
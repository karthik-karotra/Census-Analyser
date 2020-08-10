using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensorAnalyser : ICSVBuilder
    {

        public delegate object CSVFileData(string csvFilePath, string fileHeaders);
        List<string> censusData = new List<string>();

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
            censusData = File.ReadAllLines(csvFilePath).ToList();
            if (censusData[0] != fileHeaders)
            {
                throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
            }
            foreach (string data in censusData)
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }
            return censusData.Skip(1).ToList();
        }

        public object getSortedCSVDataInJsonFormat(string csvFilePath)
        {
            string[] allRecords = File.ReadAllLines(csvFilePath);
            var recordsWithoutHeader = allRecords.Skip(1);
            var sorted =
                from singleRecord in recordsWithoutHeader
                let column = singleRecord.Split(',')
                orderby column[0]
                select singleRecord;
            List<string> sortedData = sorted.ToList<string>();
            return JsonConvert.SerializeObject(sortedData);
        }
    }
}
using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensorAnalyser
    {

        public delegate object CSVFileData();
        string csvFilePath;
        string fileHeaders;
        string[] censusData;

        public CensorAnalyser(string csvFilePath, string fileHeaders)
        {
            this.csvFilePath = csvFilePath;
            this.fileHeaders = fileHeaders;
        }

        public object LoadCSVFileData()
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
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                }
            }
            return censusData.Skip(1).ToArray();
        }
    }
}
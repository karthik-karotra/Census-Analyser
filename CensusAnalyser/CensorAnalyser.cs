using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensorAnalyser
    {
        string[] censusData;
        public string[] LoadIndianCensusCSVData(string csvFilePath)
        {
            censusData = File.ReadAllLines(csvFilePath);
            return censusData.Skip(1).ToArray();
        }
    }
}
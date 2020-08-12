using CensusAnalyser.DAO;
using CensusAnalyser.POCO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class USCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, dynamic> CensusDataMap;
        public Dictionary<string, dynamic> LoadUSCensusData(string csvFilePath, string dataHeaders)
        {
            censusData = GetCensusCSVData(csvFilePath, dataHeaders);
            CensusDataMap = new Dictionary<string, dynamic>();
            foreach (string data in censusData.Skip(1))
            {
                string[] column = data.Split(",");
                CensusDataMap.Add(column[1], new USCensusDAO(new USCensus(column[0], column[1], column[2], column[3], column[4], column[5], column[6], column[7], column[8])));
            }
            return CensusDataMap;
        }
    }
}

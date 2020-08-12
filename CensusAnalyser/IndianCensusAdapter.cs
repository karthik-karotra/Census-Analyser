using CensusAnalyser.DAO;
using CensusAnalyser.POCO;
using System.Collections.Generic;
using System.Linq;

namespace CensusAnalyser
{
    public class IndianCensusAdapter : CensusAdapter
    {
        string[] censusData;
        Dictionary<string, dynamic> CensusDataMap;

        public Dictionary<string, dynamic> LoadIndianCensusData(string csvFilePath, string dataHeaders)
        {
            CensusDataMap = new Dictionary<string, dynamic>();
            censusData = GetCensusCSVData(csvFilePath, dataHeaders);
            foreach (string data in censusData.Skip(1))
            {
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                    CensusDataMap.Add(column[1], new IndianCensusDAO(new IndianStateCode(column[0], column[1], column[2], column[3])));
                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    CensusDataMap.Add(column[0], new IndianCensusDAO(new IndianCensus(column[0], column[1], column[2], column[3])));
            }
            return CensusDataMap;
        }
    }
}

using System.Collections.Generic;

namespace CensusAnalyser
{
    public class CensusAdapterFactory
    {
        public static Dictionary<string, dynamic> LoadCsvData(string csvFilePath, string fileHeaders, CensorAnalyser.Country country)
        {
            switch (country)
            {
                case (CensorAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadIndianCensusData(csvFilePath, fileHeaders);
                case (CensorAnalyser.Country.US):
                    return new USCensusAdapter().LoadUSCensusData(csvFilePath, fileHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_COUNTRY_FOUND);
            }
        }
    }
}

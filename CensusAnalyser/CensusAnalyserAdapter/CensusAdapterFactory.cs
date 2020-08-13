using System.Collections.Generic;

namespace CensusAnalyser
{
    public class CensusAdapterFactory
    {
        public static Dictionary<string, dynamic> LoadCsvData(string csvFilePath, string fileHeaders, CensusAnalyser.Country country)
        {
            switch (country)
            {
                case (CensusAnalyser.Country.INDIA):
                    return new IndianCensusAdapter().LoadIndianCensusData(csvFilePath, fileHeaders);
                case (CensusAnalyser.Country.US):
                    return new USCensusAdapter().LoadUSCensusData(csvFilePath, fileHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_COUNTRY_FOUND);
            }
        }
    }
}

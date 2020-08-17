// <copyright file="CensusAdapterFactory.cs" company="BridegLbaz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser
{
    using System.Collections.Generic;

    /// <summary>
    /// Census Adapter Factory class to return object as per the csv file of countries send.
    /// </summary>
    public class CensusAdapterFactory
    {
        /// <summary>
        /// Method to return dictionary of csv data by creating object of different adapter classes according to country provided.
        /// </summary>
        /// <param name="csvFilePath">Path of csv file.</param>
        /// <param name="fileHeaders">Headers of Csv file.</param>
        /// <param name="country">Country of which the file is.</param>
        /// <returns>Object of Different Adapter class according to country.</returns>
        public static Dictionary<string, dynamic> LoadCsvData(string csvFilePath, string fileHeaders, CensusAnalyser.Country country)
        {
            switch (country)
            {
                case CensusAnalyser.Country.INDIA:
                    return new IndianCensusAdapter().LoadIndianCensusData(csvFilePath, fileHeaders);
                case CensusAnalyser.Country.US:
                    return new USCensusAdapter().LoadUSCensusData(csvFilePath, fileHeaders);
                default:
                    throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_COUNTRY_FOUND);
            }
        }
    }
}

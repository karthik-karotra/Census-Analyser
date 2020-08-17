// <copyright file="CensusAnalyser.cs" company="BridegLbaz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyser
{
    using System.Collections.Generic;
    using System.Linq;
    using global::CensusAnalyser.POCO;
    using global::CensusAnalyser.SortAttributes;
    using Newtonsoft.Json;
    using static global::CensusAnalyser.SortAttributes.SortType;

    /// <summary>
    /// Census Analyser Class.
    /// </summary>
    public class CensusAnalyser
    {
        /// <summary>
        /// Enum Class For Countries.
        /// </summary>
        public enum Country
        {
            INDIA,
            US,
        }

        /// <summary>
        /// Common MEthod For Loading CSV Files.
        /// </summary>
        /// <param name="csvFilePath">Path Of CSV File.</param>
        /// <param name="fileHeaders">Headers Of CSV File.</param>
        /// <param name="country">Country Of Which The File Is.</param>
        /// <returns>Loaded CSV File In Dictionary.</returns>
        public Dictionary<string, dynamic> LoadCSVFileData(string csvFilePath, string fileHeaders, Country country)
        {
            return CensusAdapterFactory.LoadCsvData(csvFilePath, fileHeaders, country);
        }

        /// <summary>
        /// Method for returning CSV file in sorted format.
        /// </summary>
        /// <param name="csvFilePath">Path Of CSV File.</param>
        /// <param name="fileHeaders">Headers Of CSV File.</param>
        /// <param name="sortType">Enum For knowing what type of sorting is to be done on which column.</param>
        /// <param name="country">Country Of Which The File Is.</param>
        /// <returns>Returns object of csv file in sorted format.</returns>
        public object GetSortedCSVDataInJsonFormat(string csvFilePath, string fileHeaders, SortBy sortType, Country country)
        {
            var censusData = this.LoadCSVFileData(csvFilePath, fileHeaders, country);
            List<dynamic> sortedList = SortType.SortIndianCensusData(censusData.Values.ToList(), sortType);
            return JsonConvert.SerializeObject(sortedList);
        }

        /// <summary>
        /// Method to return densely populated state among US and India.
        /// </summary>
        /// <param name="indianCensus">Indian Census POCO class.</param>
        /// <param name="usCensus">US Census POCO class.</param>
        /// <returns>Densely populated state among US and India.</returns>
        public string GetMostPopulousStateWithDensity(IndianCensus indianCensus, USCensus usCensus)
        {
            string denselyPopulatedState = (indianCensus.PopulationDensity > usCensus.DensityPerSqKm) ? indianCensus.State : usCensus.State;
            return denselyPopulatedState;
        }
    }
}

// <copyright file="USCensusAdapter.cs" company="BridegLbaz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser
{
    using System.Collections.Generic;
    using System.Linq;
    using global::CensusAnalyser.DAO;
    using global::CensusAnalyser.POCO;

    /// <summary>
    /// US Census Adapter Class.
    /// </summary>
    public class USCensusAdapter : CensusAdapter
    {
        private string[] censusData;
        private Dictionary<string, dynamic> censusDataMap;

        /// <summary>
        /// Method for returning map of census data of US Census CSV file.
        /// </summary>
        /// <param name="csvFilePath">Path of CSV File.</param>
        /// <param name="dataHeaders">Headers of CSV File.</param>
        /// <returns>Map of census data of US Census Csv File.</returns>
        public Dictionary<string, dynamic> LoadUSCensusData(string csvFilePath, string dataHeaders)
        {
            this.censusData = this.GetCensusCSVData(csvFilePath, dataHeaders);
            this.censusDataMap = new Dictionary<string, dynamic>();
            foreach (string data in this.censusData.Skip(1))
            {
                string[] column = data.Split(",");
                this.censusDataMap.Add(column[1], new USCensusDAO(new USCensus(column[0], column[1], column[2], column[3], column[4], column[5], column[6], column[7], column[8])));
            }

            return this.censusDataMap;
        }
    }
}

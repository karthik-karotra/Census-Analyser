// <copyright file="IndianCensusAdapter.cs" company="BridegLbaz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser
{
    using System.Collections.Generic;
    using System.Linq;
    using global::CensusAnalyser.DAO;
    using global::CensusAnalyser.POCO;

    /// <summary>
    /// Indian Census Adapter Class.
    /// </summary>
    public class IndianCensusAdapter : CensusAdapter
    {
        private string[] censusData;
        private Dictionary<string, dynamic> censusDataMap;

        /// <summary>
        /// Method for returning map of census data of Indian CSV files.
        /// </summary>
        /// <param name="csvFilePath">Path of csv file.</param>
        /// <param name="dataHeaders">Headers of csv file.</param>
        /// <returns>Map of census data of Indian Csv Files.</returns>
        public Dictionary<string, dynamic> LoadIndianCensusData(string csvFilePath, string dataHeaders)
        {
            this.censusDataMap = new Dictionary<string, dynamic>();
            this.censusData = this.GetCensusCSVData(csvFilePath, dataHeaders);
            foreach (string data in this.censusData.Skip(1))
            {
                string[] column = data.Split(",");
                if (csvFilePath.Contains("IndiaStateCode.csv"))
                {
                    this.censusDataMap.Add(column[1], new IndianCensusDAO(new IndianStateCode(column[0], column[1], column[2], column[3])));
                }

                if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                {
                    this.censusDataMap.Add(column[0], new IndianCensusDAO(new IndianCensus(column[0], column[1], column[2], column[3])));
                }
            }

            return this.censusDataMap;
        }
    }
}

// <copyright file="IndianCensusDAO.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyser.DAO
{
    using global::CensusAnalyser.POCO;

    /// <summary>
    /// Indian Census DAO.
    /// </summary>
    public class IndianCensusDAO
    {
        public long areaInSqkm;
        public string state;
        public long population;
        public long densityPerSqKm;
        public int srNo;
        public int tin;
        public string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensusDAO"/> class.
        /// </summary>
        /// <param name="indianCensusCSV">Indian Census POCO class object.</param>
        public IndianCensusDAO(IndianCensus indianCensusCSV)
        {
            this.state = indianCensusCSV.State;
            this.areaInSqkm = indianCensusCSV.TotalArea;
            this.population = indianCensusCSV.Population;
            this.densityPerSqKm = indianCensusCSV.PopulationDensity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensusDAO"/> class.
        /// </summary>
        /// <param name="indianStateCode">Indian State POCO class object.</param>
        public IndianCensusDAO(IndianStateCode indianStateCode)
        {
            this.srNo = indianStateCode.SrNo;
            this.state = indianStateCode.State;
            this.tin = indianStateCode.TIN;
            this.stateCode = indianStateCode.StateCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IndianCensusDAO"/> class.
        /// </summary>
        public IndianCensusDAO()
        {
        }
    }
}

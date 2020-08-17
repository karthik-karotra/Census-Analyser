// <copyright file="USCensusDAO.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.DAO
{
    using global::CensusAnalyser.POCO;

    /// <summary>
    /// US Census DAO.
    /// </summary>
    public class USCensusDAO
    {
        public string stateCode;
        public string state;
        public long population;
        public long housingUnits;
        public double areaInSqkm;
        public double waterArea;
        public double landArea;
        public double densityPerSqKm;
        public double housingDensity;

        /// <summary>
        /// Initializes a new instance of the <see cref="USCensusDAO"/> class.
        /// </summary>
        /// <param name="usCensus">US Census POCO class object.</param>
        public USCensusDAO(USCensus usCensus)
        {
            this.stateCode = usCensus.StateCode;
            this.state = usCensus.State;
            this.population = usCensus.Population;
            this.housingUnits = usCensus.HousingUnits;
            this.areaInSqkm = usCensus.AreaInSqkm;
            this.waterArea = usCensus.WaterArea;
            this.landArea = usCensus.LandArea;
            this.densityPerSqKm = usCensus.DensityPerSqKm;
            this.housingDensity = usCensus.HousingDensity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="USCensusDAO"/> class.
        /// </summary>
        public USCensusDAO()
        {
        }
    }
}

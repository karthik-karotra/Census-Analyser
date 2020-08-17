// <copyright file="USCensus.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyser.POCO
{
    using System;
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// US Census POCO Class.
    /// </summary>
    public class USCensus
    {
        [Name("State Id")]
        public string StateCode;

        [Name("State")]
        public string State;

        [Name("Population")]
        public long Population;

        [Name("Housing units")]
        public long HousingUnits;

        [Name("Total area")]
        public double AreaInSqkm;

        [Name("Water area")]
        public double WaterArea;

        [Name("Land area")]
        public double LandArea;

        [Name("Population Density")]
        public double DensityPerSqKm;

        [Name("Housing Density")]
        public double HousingDensity;

        public USCensus(string stateCode, string state, string population, string housingUnits, string areaInSqkm, string waterArea, string landArea, string densityPerSqKm, string housingDensity)
        {
            this.StateCode = stateCode;
            this.State = state;
            this.Population = Convert.ToUInt32(population);
            this.HousingUnits = Convert.ToUInt32(housingUnits);
            this.AreaInSqkm = Convert.ToDouble(areaInSqkm);
            this.WaterArea = Convert.ToDouble(waterArea);
            this.LandArea = Convert.ToDouble(landArea);
            this.DensityPerSqKm = Convert.ToDouble(densityPerSqKm);
            this.HousingDensity = Convert.ToDouble(housingDensity);
        }
    }
}

// <copyright file="IndianCensus.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.POCO
{
    using System;
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// Indian Census POCO Class.
    /// </summary>
    public class IndianCensus
    {
        public IndianCensus(string state, string population, string totalArea, string populationDensity)
        {
            this.State = state;
            this.Population = Convert.ToUInt32(population);
            this.TotalArea = Convert.ToUInt32(totalArea);
            this.PopulationDensity = Convert.ToUInt32(populationDensity);
        }

        [Name("State")]
        public string State { get; set; }

        [Name("Population")]
        public long Population { get; set; }

        [Name("AreaInSqKm")]
        public long TotalArea { get; set; }

        [Name("DensityPerSqKm")]
        public long PopulationDensity { get; set; }
    }
}

using CsvHelper.Configuration.Attributes;
using System;

namespace CensusAnalyser.POCO
{
    public class IndianCensus
    {
        [Name("State")]
        public string state { get; set; }

        [Name("Population")]
        public long population { get; set; }

        [Name("AreaInSqKm")]
        public long totalArea { get; set; }

        [Name("DensityPerSqKm")]
        public long populationDensity { get; set; }

        public IndianCensus(string state, string population, string totalArea, string populationDensity)
        {
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.totalArea = Convert.ToUInt32(totalArea);
            this.populationDensity = Convert.ToUInt32(populationDensity);
        }
    }
}

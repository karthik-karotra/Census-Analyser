using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser.POCO
{
    public class USCensus
    {
        [Name("State Id")]
        public string stateCode;

        [Name("State")]
        public string state;

        [Name("Population")]
        public long population;

        [Name("Housing units")]
        public long housingUnits;

        [Name("Total area")]
        public double totalArea;

        [Name("Water area")]
        public double waterArea;

        [Name("Land area")]
        public double landArea;

        [Name("Population Density")]
        public double populationDensity;

        [Name("Housing Density")]
        public double housingDensity;

        public USCensus(string stateCode, string state, string population, string housingUnits, string totalArea, string waterArea, string landArea, string populationDensity, string housingDensity)
        {
            this.stateCode = stateCode;
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.housingUnits = Convert.ToUInt32(housingUnits);
            this.totalArea = Convert.ToDouble(totalArea);
            this.waterArea = Convert.ToDouble(waterArea);
            this.landArea = Convert.ToDouble(landArea);
            this.populationDensity = Convert.ToDouble(populationDensity);
            this.housingDensity = Convert.ToDouble(housingDensity);
        }
    }
}

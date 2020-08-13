using CsvHelper.Configuration.Attributes;
using System;

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
        public double areaInSqkm;

        [Name("Water area")]
        public double waterArea;

        [Name("Land area")]
        public double landArea;

        [Name("Population Density")]
        public double densityPerSqKm;

        [Name("Housing Density")]
        public double housingDensity;

        public USCensus(string stateCode, string state, string population, string housingUnits, string areaInSqkm, string waterArea, string landArea, string densityPerSqKm, string housingDensity)
        {
            this.stateCode = stateCode;
            this.state = state;
            this.population = Convert.ToUInt32(population);
            this.housingUnits = Convert.ToUInt32(housingUnits);
            this.areaInSqkm = Convert.ToDouble(areaInSqkm);
            this.waterArea = Convert.ToDouble(waterArea);
            this.landArea = Convert.ToDouble(landArea);
            this.densityPerSqKm = Convert.ToDouble(densityPerSqKm);
            this.housingDensity = Convert.ToDouble(housingDensity);
        }
    }
}

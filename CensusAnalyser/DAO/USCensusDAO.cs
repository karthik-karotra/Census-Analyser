using CensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser.DAO
{
    public class USCensusDAO
    {
        public string stateCode;
        public String state;
        public long population;
        public long housingUnits;
        public double totalArea;
        public double waterArea;
        public double landArea;
        public double populationDensity;
        public double housingDensity;

        public USCensusDAO(USCensus usCensus)
        {
            this.stateCode = usCensus.stateCode;
            this.state = usCensus.state;
            this.population = usCensus.population;
            this.housingUnits = usCensus.housingUnits;
            this.totalArea = usCensus.totalArea;
            this.waterArea = usCensus.waterArea;
            this.landArea = usCensus.landArea;
            this.populationDensity = usCensus.populationDensity;
            this.housingDensity = usCensus.housingDensity;
        }
    }
}

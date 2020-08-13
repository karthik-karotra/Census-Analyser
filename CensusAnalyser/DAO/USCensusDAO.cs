using CensusAnalyser.POCO;

namespace CensusAnalyser.DAO
{
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

        public USCensusDAO(USCensus usCensus)
        {
            this.stateCode = usCensus.stateCode;
            this.state = usCensus.state;
            this.population = usCensus.population;
            this.housingUnits = usCensus.housingUnits;
            this.areaInSqkm = usCensus.areaInSqkm;
            this.waterArea = usCensus.waterArea;
            this.landArea = usCensus.landArea;
            this.densityPerSqKm = usCensus.densityPerSqKm;
            this.housingDensity = usCensus.housingDensity;
        }

        public USCensusDAO() { }
    }
}

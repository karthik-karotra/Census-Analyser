using CensusAnalyser.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser.DAO
{
    public class IndianCensusDAO
    {
        public long areaInSqkm;
        public String state;
        public long population;
        public long densityPerSqKm;
        public int srNo;
        public int TIN;
        public string stateCode;

        public IndianCensusDAO(IndianCensus indianCensusCSV)
        {
            state = indianCensusCSV.state;
            areaInSqkm = indianCensusCSV.totalArea;
            population = indianCensusCSV.population;
            densityPerSqKm = indianCensusCSV.populationDensity;
        }

        public IndianCensusDAO(IndianStateCode indianStateCode)
        {
            srNo = indianStateCode.srNo;
            state = indianStateCode.state;
            TIN = indianStateCode.TIN;
            stateCode = indianStateCode.stateCode;
        }

        public IndianCensusDAO() { }

    }
}

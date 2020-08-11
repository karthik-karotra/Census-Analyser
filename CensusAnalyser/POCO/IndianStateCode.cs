using CsvHelper.Configuration.Attributes;
using System;

namespace CensusAnalyser.POCO
{
    public class IndianStateCode
    {
        [Name("SrNo")]
        public int srNo { get; set; }

        [Name("State Name")]
        public string state { get; set; }

        [Name("TIN")]
        public int TIN { get; set; }

        [Name("StateCode")]
        public string stateCode { get; set; }

        public IndianStateCode(string srNo, string state, string TIN, string stateCode)
        {
            this.srNo = Convert.ToInt32(srNo);
            this.state = state;
            this.TIN = Convert.ToInt32(TIN);
            this.stateCode = stateCode;
        }
    }
}

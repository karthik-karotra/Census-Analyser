// <copyright file="IndianStateCode.cs" company="BridegLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CensusAnalyser.POCO
{
    using System;
    using CsvHelper.Configuration.Attributes;

    /// <summary>
    /// Indian State Code POCO class.
    /// </summary>
    public class IndianStateCode
    {
        public IndianStateCode(string srNo, string state, string tin, string stateCode)
        {
            this.SrNo = Convert.ToInt32(srNo);
            this.State = state;
            this.TIN = Convert.ToInt32(tin);
            this.StateCode = stateCode;
        }

        [Name("SrNo")]
        public int SrNo { get; set; }

        [Name("State Name")]
        public string State { get; set; }

        [Name("tin")]
        public int TIN { get; set; }

        [Name("StateCode")]
        public string StateCode { get; set; }
    }
}

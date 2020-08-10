using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CSVFactory
    {

        public ICSVBuilder getCensusAnalyser()
        {
            return new CensorAnalyser();
        }
    }
}

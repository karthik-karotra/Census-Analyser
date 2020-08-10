using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        object LoadCSVFileData(string csvFilePath, string fileHeaders);
    }
}

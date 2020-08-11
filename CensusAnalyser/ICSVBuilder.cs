using CensusAnalyser.DAO;
using System.Collections.Generic;

namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        object LoadCSVFileData(string csvFilePath, string fileHeaders);
    }
}

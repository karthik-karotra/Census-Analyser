namespace CensusAnalyser
{
    public interface ICSVBuilder
    {
        object LoadCSVFileData(string csvFilePath, string fileHeaders);
    }
}

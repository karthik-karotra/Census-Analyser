namespace CensusAnalyser
{
    public class CSVFactory
    {

        public ICSVBuilder GetCensusAnalyser()
        {
            return new CensorAnalyser();
        }
    }
}

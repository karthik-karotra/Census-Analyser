﻿using System.IO;
using System.Linq;

namespace CensusAnalyser
{
    public class CensorAnalyser
    {
        string[] censusData;
        public string[] LoadIndianCensusCSVData(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
            }
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException("Incorrect Type", CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE);
            }
            censusData = File.ReadAllLines(csvFilePath);
            return censusData.Skip(1).ToArray();
        }
    }
}
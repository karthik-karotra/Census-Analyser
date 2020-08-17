// <copyright file="CensusAdapter.cs" company="BridegLbaz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyser
{
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Abstract Census Adapter Class.
    /// </summary>
    public abstract class CensusAdapter
    {
        /// <summary>
        /// Method for getting census data from CSV file.
        /// </summary>
        /// <param name="csvFilePath">Path of csv file.</param>
        /// <param name="fileHeaders">Headers of csv files.</param>
        /// <returns>Returns census data from file.</returns>
        protected string[] GetCensusCSVData(string csvFilePath, string fileHeaders)
        {
                string[] censusData;
                if (!File.Exists(csvFilePath))
                {
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
                }

                if (Path.GetExtension(csvFilePath) != ".csv")
                {
                    throw new CensusAnalyserException("Incorrect Type", CensusAnalyserException.ExceptionType.INCORRECT_FILE_TYPE);
                }

                censusData = File.ReadAllLines(csvFilePath);
                if (censusData[0] != fileHeaders)
                {
                    throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
                }

                foreach (string data in censusData.Skip(1))
                {
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("Invalid Delimiters In File", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                    }
                }

                return censusData;
        }
    }
}

// <copyright file="CensusAnalyserException.cs" company="BridgeLabz Solution">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace CensusAnalyser
{
    using System;

    /// <summary>
    /// Custom Exception Class.
    /// </summary>
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;

        /// <summary>
        /// Initializes a new instance of the <see cref="CensusAnalyserException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="type">Exception type.</param>
        public CensusAnalyserException(string message, ExceptionType type)
            : base(string.Format(message))
        {
            this.type = type;
        }

        /// <summary>
        /// Enum class for exception type.
        /// </summary>
        public enum ExceptionType
        {
            FILE_NOT_FOUND,
            INCORRECT_FILE_TYPE,
            INVALID_DELIMITER,
            INVALID_HEADERS,
            NO_COUNTRY_FOUND,
        }
    }
}

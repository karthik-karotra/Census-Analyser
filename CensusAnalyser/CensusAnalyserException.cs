using System;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INCORRECT_FILE_TYPE, INVALID_DELIMITER, INVALID_HEADERS, NO_COUNTRY_FOUND
        }
        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}

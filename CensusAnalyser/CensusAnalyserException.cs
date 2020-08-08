using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND
        }
        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}

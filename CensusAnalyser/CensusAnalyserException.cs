﻿using System;

namespace CensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            FILE_NOT_FOUND,INCORRECT_FILE_TYPE
        }
        public ExceptionType type;

        public CensusAnalyserException(String message, ExceptionType type) : base(String.Format(message))
        {
            this.type = type;
        }
    }
}

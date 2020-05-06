///-----------------------------------------------------------------
///   Class:     CustomException
///   Description: Class Custom Exception for throw Exception
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using System;

namespace CensusAnalyzer
{
    /// <summary>
    ///Class CustomException is used for Exception Handling
    /// </summary>
    public class CustomException : Exception
    {
        public string message;
        public enum ExceptionType
        {
            File_Path_Incorrect,
            File_Type_Incorrect,
            Incorrect_Delimiter,
            Incorrect_Header
        }
        public double GetMessage { get; set; }

        public CustomException(string message, ExceptionType incorrect_Delimiter) : base(message)
        {
        }
    }
}
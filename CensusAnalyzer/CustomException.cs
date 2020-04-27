///-----------------------------------------------------------------
///   Class:     CustomException.cs
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
       
        public string GetMessage { get => this.message; }
        //constructor
        public CustomException(string message)
        {
            this.message = message;
        }
    }
}
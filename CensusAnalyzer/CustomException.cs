using System;
using System.Runtime.Serialization;

namespace CensusAnalyser
{
    public class CustomException : Exception
    {
        public string message;
        private Exception file_format_Incorrect;
        public string GetMessage { get => this.message; }
        //constructor
        public CustomException(string message)
        {
            this.message = message;
        }
    }
}
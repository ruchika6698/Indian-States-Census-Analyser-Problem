using System;
using System.Runtime.Serialization;

namespace CensusAnalyser
{
    public class CustomException : Exception
    { 
        public string message;
        public CustomException(string message)
        {
            this.message = message;
        }
        public override string Message
        {
            get
            {
                return this.message;
            }
        }
    }
}
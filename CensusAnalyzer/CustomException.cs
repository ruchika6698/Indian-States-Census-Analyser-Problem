using System;
using System.Runtime.Serialization;

namespace CensusAnalyser
{
    public class CustomException : Exception
    {
        public Exception type;
        public enum Exception
        {
            File_not_found,
            File_format_Incorrect,
            Delimiter_Incorrect
        }
        public string message;
        public CustomException(string message, Exception type)
        {
            this.message = message;
            this.type= type;
        }

        public CustomException(string message) : base(message)
        {
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
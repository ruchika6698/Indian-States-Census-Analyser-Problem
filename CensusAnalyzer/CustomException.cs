using System;
using System.Runtime.Serialization;

namespace CensusAnalyser
{
    public class CustomException : Exception
    {
        public enum Exception_type
        {
            File_not_found,
            File_format_Incorrect
        }
        public string message;
        public CustomException(string message)
        {
            this.message = message;
        }

        public CustomException(string message, Exception_type file_format_Incorrect) : this(message)
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
﻿using System;
using System.Runtime.Serialization;

namespace CensusAnalyser
{
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
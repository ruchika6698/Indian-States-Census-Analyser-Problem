///-----------------------------------------------------------------
///   Class:       StateCensusAnalyzer.cs
///   Description: method for State Census Data File
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using System;

namespace CensusAnalyzer
{
    public class StateCensusAnalyzer : ICSVBuilder
    {
        public string filepath;
      
        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to Census Analysis for country US and India");
        }
        /// <summary>
        ///Method to find Number of records in file for state census data
        /// </summary>
        public delegate int GetCSVCount(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int numberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            try
            {
                //check for filetype
                bool type = CSVOperations.CheckFileType(filepath, ".csv");
                string[] records = CSVOperations.ReadCSVFile(filepath);
                //check for delimiter
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                //check for Header
                bool head = CSVOperations.CheckForHeader(records, header);
                //check for Number of Records
                int count = CSVOperations.CountRecords(records);
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

        int ICSVBuilder.numberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.getDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.USCensusRecords(string uscensus)
        {
            throw new NotImplementedException();
        }
    }
}
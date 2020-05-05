///-----------------------------------------------------------------
///   Class:       IndianCensusData
///   Description: class for State Census Data File
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using System;

namespace CensusAnalyzer
{
    public class IndianCensusData : ICSVBuilder
    {
        public string filePath;
      
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
        /// <param name="filePath"> Indian census data path </param>
        /// <param name="delimiter"> Delimiter </param>
        /// <param name="header"> Header </param>
        /// <returns> Indian Census Record </returns>
        public delegate int GetIndianCensusCSVCount(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        public static int NumberOfRecords(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm")
        {
            //check for filetype
            bool type = CSVOperations.CheckFileType(filePath, ".csv");
            string[] records = CSVOperations.ReadCSVFile(filePath);
            //check for delimiter
            bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
            //check for Header
            bool head = CSVOperations.CheckForHeader(records, header);
            //check for Number of Records
            int count = CSVOperations.CountRecords(records);
            return count;
        }

        int ICSVBuilder.NumberOfRecords(string filepath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.GetDataFromCSVFile(string statecode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.USCensusRecords(string uscensus)
        {
            throw new NotImplementedException();
        }
    }
}
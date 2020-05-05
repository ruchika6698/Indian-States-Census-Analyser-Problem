///-----------------------------------------------------------------
///   Class:       StateCodeCensusDAO
///   Description: class for StateCode File
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using System;

namespace CensusAnalyzer
{
    public class StateCodeCensusDAO : ICSVBuilder
    {
        public string stateCode;
        public delegate int GetCountFromCSVStates(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        /// <summary>
        ///Method to find Number of records in file for StateCode csv file
        /// </summary>
        /// <param name="stateCode"> State Code data path </param>
        /// <param name="delimiter"> Delimiter </param>
        /// <param name="header"> Header </param>
        /// <returns> Data count,delimiter,header </returns>
        public static int GetDataFromCSVFile(string stateCode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode")
        {
            //check file type
            bool type = CSVOperations.CheckFileType(stateCode, ".csv");
            string[] records = CSVOperations.ReadCSVFile(stateCode);
            //check for delimiter
            bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
            //check for delimiter
            bool head = CSVOperations.CheckForHeader(records, header);
            //check for Number of Records
            int count = CSVOperations.CountRecords(records);
            return count;
        }

        int ICSVBuilder.NumberOfRecords(string filePath, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.GetDataFromCSVFile(string stateCode, char delimiter, string header)
        {
            throw new NotImplementedException();
        }

        int ICSVBuilder.USCensusRecords(string usCensus)
        {
            throw new NotImplementedException();
        }
    }
}
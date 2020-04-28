///-----------------------------------------------------------------
///   Class:       StateCodeCensusDAO
///   Description: method for StateCode File
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using System;

namespace CensusAnalyzer
{
    public class StateCodeCensusDAO : ICSVBuilder
    {
        public string statecode;
        public delegate int GetCountFromCSVStates(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        /// <summary>
        ///Method to find Number of records in file for StateCode csv file
        /// </summary>
        public static int getDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode")
        {
            try
            {
                //check file type
                bool type = CSVOperations.CheckFileType(statecode, ".csv");
                string[] records = CSVOperations.ReadCSVFile(statecode);
                //check for delimiter
                bool delimit = CSVOperations.CheckForDelimiter(records, delimiter);
                //check for delimiter
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
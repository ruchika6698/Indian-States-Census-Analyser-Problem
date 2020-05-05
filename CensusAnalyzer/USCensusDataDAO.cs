///-----------------------------------------------------------------
///   Class:      USCensusDataDAO
///   Description: class for USCensusData
///   Author:      Ruchika                   Date: 27/4/2020
///--------------------------------------------------------------

using System;

namespace CensusAnalyzer
{
    public class USCensusDataDAO : ICSVBuilder
    {
        /// <summary>
        ///Method to find Number of records in file for US Census Data csv file
        /// </summary>
        /// <param name="uscensus"> uscensus data path </param>
        /// <returns> US Census Record </returns>
        public delegate int GetUSCSVCount(string usCensus);
        public static int USCensusRecords(string usCensus)
        {
            //check file type
            bool type = CSVOperations.CheckFileType(usCensus, ".csv");
            string[] records = CSVOperations.ReadCSVFile(usCensus);
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

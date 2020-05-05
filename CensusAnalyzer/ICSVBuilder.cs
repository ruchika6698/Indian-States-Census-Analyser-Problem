///-----------------------------------------------------------------
///   Class:      ICSVBuilder
///   Description: Created a Interface for Classes
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------
using System;
namespace CensusAnalyzer
{
    public interface ICSVBuilder
    {
        //method for State Census Data
        public int NumberOfRecords(string filePath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        //method for State Code
        public int GetDataFromCSVFile(string stateCode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        //method for USCensus Data
        public int USCensusRecords(string usCensus);
    }
}
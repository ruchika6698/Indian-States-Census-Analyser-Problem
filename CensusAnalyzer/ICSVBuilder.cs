///-----------------------------------------------------------------
///   Class:      ICSVBuilder.cs
///   Description: Created a Interface for Classes
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

namespace CensusAnalyzer
{
    public interface ICSVBuilder
    {
        //interface State Census Data
        public int numberOfRecords(string filepath, char delimiter = ',', string header = "State,Population,AreaInSqKm,DensityPerSqKm");
        //interaface State Code
        public int getDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode");
        //interface for USCensus Data
        public int USCensusRecords(string uscensus);
    }
}
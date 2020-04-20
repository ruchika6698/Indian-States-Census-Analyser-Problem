using CensusAnalyser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    public class CSVStatesCensus
    {
        public static object getDataFromCSVFile(string statecode)
        {
            try
            {
                if (statecode != @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.csv")
                {
                    throw new CustomException("file path incorrect");
                }
                string[] data = File.ReadAllLines(statecode);
                return data.Length;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }

}

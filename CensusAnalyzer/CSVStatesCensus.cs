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
                if (Path.GetExtension(statecode) != ".csv")
                {
                    throw new CustomException("File_format_Incorrect");
                }
                if (statecode != @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensus.csv")
                {
                    throw new CustomException("File_not_found");
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

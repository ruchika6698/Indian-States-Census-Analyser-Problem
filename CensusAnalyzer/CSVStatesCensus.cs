using CensusAnalyser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    public class CSVStatesCensus
    {
        private static char delimiter;

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
                //check delimiter is correct or incorrect
                foreach (string str in data)
                {

                    if (str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CustomException("Incorrect Delimiter");
                    }
                }
                return data.Length;
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }

}

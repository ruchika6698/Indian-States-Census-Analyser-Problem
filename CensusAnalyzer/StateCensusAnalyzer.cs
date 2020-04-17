using System;
using System.IO;

namespace CensusAnalyser
{
    public class StateCensusAnalyzer
    {
        private object filepath;
        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }
        /// <summary>
        ///Method to find Number of records in file
        /// </summary>
        public static object numberOfRecords(string filepath)
        {
            try
            {
                if (filepath != @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv")
                {
                    throw new CustomException("File not found");
                }
                string[] data = File.ReadAllLines(filepath);
                return data.Length - 1;
            }
            catch(CustomException e)
            {
                return e.Message;
            }
        }
    }
}

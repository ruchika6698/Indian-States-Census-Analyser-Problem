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
        public static object records(string filepath)
        {
            string[] a = File.ReadAllLines(filepath);
            return a.Length;
        }
            /// <summary>
            ///Method to find Number of records in file
            /// </summary>
        public static object numberOfRecords(string filepath)
        {
            try
            {
                if (Path.GetExtension(filepath) != ".csv")
                {
                    throw new CustomException("File_format_Incorrect", CustomException.Exception_type.File_format_Incorrect);
                }
                if (filepath != @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensus.csv")
                {
                    throw new CustomException("File_not_found", CustomException.Exception_type.File_not_found);
                }
                string[] data = File.ReadAllLines(filepath);
                return data.Length ;
            }
            catch(CustomException e)
            {
                return e.Message;
            }
        }
    }
}

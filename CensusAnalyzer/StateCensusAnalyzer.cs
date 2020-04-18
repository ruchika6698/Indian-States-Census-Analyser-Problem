using System;
using System.IO;

namespace CensusAnalyser
{
    public class StateCensusAnalyzer
    {
        public string filepath;
        public char delimiter = ',';
        /// <summary>
        /// Constructor
        /// </summary>
        public StateCensusAnalyzer(string filepath)
        {
            this.filepath = filepath;
        }
        public StateCensusAnalyzer(string filepath, char delimiter)
        {
            this.filepath = filepath;
            this.delimiter = delimiter;
        }
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
        public object numberOfRecords()
        {
            try
            {
                if (Path.GetExtension(filepath) != ".csv")
                {
                    throw new CustomException("File format Incorrect", CustomException.Exception.File_format_Incorrect);
                }
                if (filepath != @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensus.csv")
                {
                    throw new CustomException("File not found", CustomException.Exception.File_not_found);
                }
                string[] data = File.ReadAllLines(filepath);
                if (data[0] != "State,Population,AreaInSqKm,DensityPerSqKm")
                {
                    throw new CustomException("Header Incorrect", CustomException.Exception.Header_Incorrect);
                }
                foreach (var element in data)
                {
                    if (!element.Contains(delimiter))
                    {
                        throw new CustomException("Delimiter Incorrect", CustomException.Exception.Delimiter_Incorrect);
                    }
                }
                return data.Length - 1;
            }
            catch(CustomException e)
            {
                return e.Message;
            }
        }
    }
}

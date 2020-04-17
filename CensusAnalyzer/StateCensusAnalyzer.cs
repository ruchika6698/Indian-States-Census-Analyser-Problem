using System;
using System.IO;

namespace CensusAnalyser
{
    public class StateCensusAnalyzer
    {
        private object filepath;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to India state census Analyzer");
        }
        public static int numberOfRecords(string filepath)
        {
            string[] data = File.ReadAllLines(filepath);
            return data.Length - 1;
        }
    }
}

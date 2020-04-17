using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    class CsvStateCensus
    {
        /// <summary>
        /// GETS THE NUMBER OF RECORDS
        /// </summary>
        public static int getnumberOfRecords(string filepath)
        {
            try
            {
                int count = 0;
                string[] elements = File.ReadAllLines(filepath);
                IEnumerable<string> e = elements;
                foreach (var element in e)
                {
                    count++;
                }
                return count - 1;
            }
            catch(CustomException)
            {
                throw new CustomException("File_not_found");
            }
        }
    }
}

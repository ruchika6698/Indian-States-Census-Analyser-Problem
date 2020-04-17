using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    class CsvStateCensus
    {
        //GETS THE NUMBER OF RECORDS
        public static int getnumberOfRecords(string filepath)
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
    }
}

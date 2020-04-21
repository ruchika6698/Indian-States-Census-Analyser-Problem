using System;
using System.Collections.Generic;
using System.Text;
using static CensusAnalyzer.StateCensusAnalyzer;
using static CensusAnalyzer.CSVStatesCensus;

namespace CensusAnalyzer
{
    public class CSVFactory
    {
        public static StateCensusAnalyzer InstanceOfStateCensusAnalyzer()
        {
            return new StateCensusAnalyzer();
        }
        public static CSVStatesCensus InstanceOfCSVStatesCensus()
        {
            return new CSVStatesCensus();
        }

        public static GetCSVCount DelegateofStateCensusAnalyse()
        {
            StateCensusAnalyzer csvStateCensus = InstanceOfStateCensusAnalyzer();
            GetCSVCount getCSVCount = new GetCSVCount(StateCensusAnalyzer.numberOfRecords);
            return getCSVCount;
        }
        public static GetCountFromCSVStates DelegateofStatecode()
        {
            CSVStatesCensus statesCodeCSV = InstanceOfCSVStatesCensus();
            GetCountFromCSVStates referToCSVSates = new GetCountFromCSVStates(CSVStatesCensus.getDataFromCSVFile);
            return referToCSVSates;
        }
    }
}

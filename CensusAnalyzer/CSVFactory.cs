///-----------------------------------------------------------------
///   Class:       CSVFactory
///   Description: Create a object for StateCensus Data,StateCode and USCensus
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using static CensusAnalyzer.IndianCensusData;
using static CensusAnalyzer.StateCodeCensusDAO;
using static CensusAnalyzer.USCensusDataDAO;

namespace CensusAnalyzer
{
    public class CSVFactory
    {
        public static IndianCensusData InstanceOfStateCensusAnalyzer()
        {
            return new IndianCensusData();
        }
        public static StateCodeCensusDAO InstanceOfCSVStatesCensus()
        {
            return new StateCodeCensusDAO();
        }
        public static USCensusDataDAO InstanceOfUSCensus()
        {
            return new USCensusDataDAO();
        }
        /// <summary>
        ///Method to create object for State Census Data
        /// </summary>
        public static GetIndianCensusCSVCount DelegateofStateCensusAnalyse()
        {
            IndianCensusData csvStateCensus = InstanceOfStateCensusAnalyzer();
            GetIndianCensusCSVCount getCSVCount = new GetIndianCensusCSVCount(IndianCensusData.numberOfRecords);
            return getCSVCount;
        }
        /// <summary>
        ///Method to create object for State Code csv
        /// </summary>
        public static GetCountFromCSVStates DelegateofStatecode()
        {
            StateCodeCensusDAO statesCodeCSV = InstanceOfCSVStatesCensus();
            GetCountFromCSVStates referToCSVSates = new GetCountFromCSVStates(StateCodeCensusDAO.getDataFromCSVFile);
            return referToCSVSates;
        }
        /// <summary>
        ///Method to create object for US census Data
        /// </summary>
        public static GetUSCSVCount DelegateofUSCensusData()
        {
            USCensusDataDAO csvUSCensus = InstanceOfUSCensus();
            GetUSCSVCount getCSVCount = new GetUSCSVCount(USCensusDataDAO.USCensusRecords);
            return getCSVCount;
        }
    }
}
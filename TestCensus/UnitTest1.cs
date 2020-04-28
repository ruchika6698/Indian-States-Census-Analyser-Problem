///-----------------------------------------------------------------
///   Class:       Tests
///   Description: Test cases for India Census & USCensus analysis data
///   Author:      Ruchika                   Date: 27/4/2020
///------------------------------------------------------------------

using NUnit.Framework;
using static CensusAnalyzer.IndianCensusData;
using static CensusAnalyzer.StateCodeCensusDAO;
using CensusAnalyser;

namespace CensusAnalyzer
{
    public class Tests
    {
        GetIndianCensusCSVCount csvstatecensus = CSVFactory.DelegateofStateCensusAnalyse();
        GetCountFromCSVStates statesCodeCSV = CSVFactory.DelegateofStatecode();

        public string IndianCensusdata = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
        public string statecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.csv";
        public string uscensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\USCensusData.csv";
        public string jsonPathIndianCensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.JSON";
        public string jsonPathstatecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.JSON";
        public string jsonPathUSCensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\USCensusData.JSON";

        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int actual = CSVOperations.numberOfRecords(IndianCensusdata);
            Assert.AreEqual(29, actual);
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrectpath = Assert.Throws<CustomException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\StateCensusData.csv"));
            Assert.AreEqual("file path incorrect", incorrectpath.GetMessage);
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            var incorrecttype = Assert.Throws<CustomException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.txt"));
            Assert.AreEqual("File type incorrect", incorrecttype.GetMessage);
        }
        /// <summary>
        ///TC-1.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectDelimiter = Assert.Throws<CustomException>(() => csvstatecensus(IndianCensusdata, '.'));
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectHeader = Assert.Throws<CustomException>(() => csvstatecensus(IndianCensusdata, ',', "St,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            int actual = CSVOperations.numberOfRecords(statecode);
            Assert.AreEqual(37, actual);
        }
        /// <summary>
        ///TC-2.2:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectpath = Assert.Throws<CustomException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\StateCode.csv"));
            Assert.AreEqual("file path incorrect", incorrectpath.GetMessage);
        }
        /// <summary>
        ///TC-2.3:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrecttype = Assert.Throws<CustomException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.txt"));
            Assert.AreEqual("File type incorrect", incorrecttype.GetMessage);
        }
        /// <summary>
        ///TC-2.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectDelimiter = Assert.Throws<CustomException>(() => statesCodeCSV(IndianCensusdata, '.'));
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-2.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectHeader = Assert.Throws<CustomException>(() => statesCodeCSV(IndianCensusdata, ',', "SrN,State,TIN,StateCode"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }
        /// <summary>
        ///UC-3 : Givens the first state of the CSV and json path to add into j son after sorting when analyse return.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(IndianCensusdata, jsonPathIndianCensus, "State");
            Assert.AreEqual("Andhra Pradesh", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(IndianCensusdata, jsonPathIndianCensus, "State");
            Assert.AreEqual("West Bengal", lastValue);
        }
        /// <summary>
        /// UC-4 :Givens the state of the CSV and json path to add into j son after sorting when analyse returnlast
        /// </summary>
        [Test]
        public void GivenCSVStateCodeAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(statecode, jsonPathstatecode, "StateCode");
            Assert.AreEqual("AD", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(statecode, jsonPathstatecode, "StateCode");
            Assert.AreEqual("WB", lastValue);
        }
        /// <summary>
        /// UC-5 :Given the CSV state census and json to sort from most populous to least when analyse return the number of states sorted.
        /// </summary>
        [Test]
        public void GivenCsvStateCensusAndJson_ToSortFromMostPopulousToLeast_WhenAnalyse_ReturnTheNumberOfSatetesSorted()
        {
            string population = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, jsonPathIndianCensus, "Population");
            Assert.AreEqual("199812341", population);
        }
        /// <summary>
        /// UC-6 :Givens the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensity_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, jsonPathIndianCensus, "DensityPerSqKm");
            Assert.AreEqual("1102", lastValue);
        }
        /// <summary>
        /// UC-7 :Givens the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnArea_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, jsonPathIndianCensus, "AreaInSqKm");
            Assert.AreEqual("342239", lastValue);
        }
        /// <summary>
        ///UC-8: Test for checking number of Records in USCensus Data CSV file
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheUSCensusData()
        {
            int actual = USCensusDataDAO.USCensusRecords(uscensus);
            Assert.AreEqual(51, actual);
        }
        /// <summary>
        /// UC-9 :Givens the state of the CSV and json path to add into json after sorted based on population using UScensus
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnPopulation_WhenAnalyse_ReturnMostPopulationState()
        {
            string population = JSONCensus.SortCSVInJsonAndReturnData(uscensus, jsonPathUSCensus, "Population");
            Assert.AreEqual("37253956", population);
        }
        /// <summary>
        /// UC-10:  the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnPopulationDensity_WhenAnalyse_ReturnPopulationDensity()
        {
            string PopulationDensity = JSONCensus.SortCSVInJsonAndReturnData(uscensus, jsonPathUSCensus, "Population Density");
            Assert.AreEqual("3805.61", PopulationDensity);
        }
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensityArea_WhenAnalyse_ReturnPopulationArea()
        {
            string Totalarea = JSONCensus.SortCSVInJsonAndReturnData(uscensus, jsonPathUSCensus, "Total area");
            Assert.AreEqual("1723338.01", Totalarea);
        }
        /// <summary>
        /// UC-11:  In India and US which contry has most populous state with Density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensityArea_WhenAnalyse_ReturnPopulationstateforIndiaAndUS()
        {
            string lastValue = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, jsonPathIndianCensus, "DensityPerSqKm");
            string PopulationDensity = JSONCensus.SortCSVInJsonAndReturnData(uscensus, jsonPathUSCensus, "Population Density");
            Assert.IsTrue(lastValue.ToString().CompareTo(PopulationDensity.ToString()) < 0);
        }
    }
}

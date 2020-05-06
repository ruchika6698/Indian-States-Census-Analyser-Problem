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
        public string Statecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.csv";
        public string Uscensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\USCensusData.csv";
        public string JsonPathIndianCensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.JSON";
        public string JsonPathstatecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.JSON";
        public string JsonPathUSCensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\USCensusData.JSON";

        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int actual = CSVOperations.NumberOfRecords(IndianCensusdata);
            Assert.AreEqual(29, actual);
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            try
            {
                var incorrectpath = csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\StateCensusData.csv");
                Assert.AreEqual("file path incorrect", incorrectpath);
            }
            catch (CustomException e)
            {
                Assert.AreEqual("file path incorrect", e.Message);
            }
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            try
            {
                var incorrecttype = Assert.Throws<CustomException>(() => csvstatecensus(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.txt"));
            }
            catch (CustomException e)
            {
                Assert.AreEqual("File type incorrect", e.Message);
            }
        }
        /// <summary>
        ///TC-1.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            try
            {
                var incorrectDelimiter = Assert.Throws<CustomException>(() => csvstatecensus(IndianCensusdata, '.'));
            }
            catch (CustomException e)
            {
                Assert.AreEqual("Incorrect Delimiter", e.Message);
            }
        }
        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            try
            {
                var incorrectHeader = Assert.Throws<CustomException>(() => csvstatecensus(IndianCensusdata, ',', "St,Population,AreaInSqKm,DensityPerSqKm"));
            }
            catch (CustomException e)
            {
                Assert.AreEqual("Incorrect header", e.Message);
            } 
        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            int actual = CSVOperations.NumberOfRecords(Statecode);
            Assert.AreEqual(37, actual);
        }
        /// <summary>
        ///TC-2.2:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                var incorrectpath = statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\StateCode.csv");
                Assert.AreEqual("file path incorrect", incorrectpath);
            }
            catch (CustomException e)
            {
                Assert.AreEqual("file path incorrect", e.Message);
            }
        }
        /// <summary>
        ///TC-2.3:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                var incorrecttype = Assert.Throws<CustomException>(() => statesCodeCSV(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.txt"));
            }
            catch (CustomException e)
            {
                Assert.AreEqual("File type incorrect", e.Message);
            }
        }
        /// <summary>
        ///TC-2.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                var incorrectDelimiter = Assert.Throws<CustomException>(() => statesCodeCSV(IndianCensusdata, '.'));
            }
            catch (CustomException e)
            {
                Assert.AreEqual("Incorrect Delimiter", e.Message);
            }
        }
        /// <summary>
        ///TC-2.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            try
            {
                var incorrectHeader = Assert.Throws<CustomException>(() => statesCodeCSV(IndianCensusdata, ',', "SrN,State,TIN,StateCode"));
            }
            catch (CustomException e)
            {
                Assert.AreEqual("Incorrect header", e.Message);
            }
        }
        /// <summary>
        ///UC-3 : Givens the first state of the CSV and json path to add into j son after sorting when analyse return.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(IndianCensusdata, JsonPathIndianCensus, "State");
            Assert.AreEqual("Andhra Pradesh", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(IndianCensusdata, JsonPathIndianCensus, "State");
            Assert.AreEqual("West Bengal", lastValue);
        }
        /// <summary>
        /// UC-4 :Givens the state of the CSV and json path to add into j son after sorting when analyse returnlast
        /// </summary>
        [Test]
        public void GivenCSVStateCodeAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(Statecode, JsonPathstatecode, "StateCode");
            Assert.AreEqual("AD", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(Statecode, JsonPathstatecode, "StateCode");
            Assert.AreEqual("WB", lastValue);
        }
        /// <summary>
        /// UC-5 :Given the CSV state census and json to sort from most populous to least when analyse return the number of states sorted.
        /// </summary>
        [Test]
        public void GivenCsvStateCensusAndJson_ToSortFromMostPopulousToLeast_WhenAnalyse_ReturnTheNumberOfSatetesSorted()
        {
            string population = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, JsonPathIndianCensus, "Population");
            Assert.AreEqual("199812341", population);
        }
        /// <summary>
        /// UC-6 :Givens the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensity_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, JsonPathIndianCensus, "DensityPerSqKm");
            Assert.AreEqual("1102", lastValue);
        }
        /// <summary>
        /// UC-7 :Givens the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnArea_WhenAnalyse_ReturnlastState()
        {
            string lastValue = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, JsonPathIndianCensus, "AreaInSqKm");
            Assert.AreEqual("342239", lastValue);
        }
        /// <summary>
        ///UC-8: Test for checking number of Records in USCensus Data CSV file
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheUSCensusData()
        {
            int actual = USCensusDataDAO.USCensusRecords(Uscensus);
            Assert.AreEqual(51, actual);
        }
        /// <summary>
        /// UC-9 :Givens the state of the CSV and json path to add into json after sorted based on population using UScensus
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnPopulation_WhenAnalyse_ReturnMostPopulationState()
        {
            string population = JSONCensus.SortCSVInJsonAndReturnData(Uscensus, JsonPathUSCensus, "Population");
            Assert.AreEqual("37253956", population);
        }
        /// <summary>
        /// UC-10:  the state of the CSV and json path to add into json after sorted based on population and density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnPopulationDensity_WhenAnalyse_ReturnPopulationDensity()
        {
            string PopulationDensity = JSONCensus.SortCSVInJsonAndReturnData(Uscensus, JsonPathUSCensus, "Population Density");
            Assert.AreEqual("3805.61", PopulationDensity);
        }
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensityArea_WhenAnalyse_ReturnPopulationArea()
        {
            string Totalarea = JSONCensus.SortCSVInJsonAndReturnData(Uscensus, JsonPathUSCensus, "Total area");
            Assert.AreEqual("1723338.01", Totalarea);
        }
        /// <summary>
        /// UC-11:  In India and US which contry has most populous state with Density
        /// </summary> 
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSortingOnDensityArea_WhenAnalyse_ReturnPopulationstateforIndiaAndUS()
        {
            string lastValue = JSONCensus.SortCSVInJsonAndReturnData(IndianCensusdata, JsonPathIndianCensus, "DensityPerSqKm");
            string PopulationDensity = JSONCensus.SortCSVInJsonAndReturnData(Uscensus, JsonPathUSCensus, "Population Density");
            Assert.IsTrue(lastValue.ToString().CompareTo(PopulationDensity.ToString()) < 0);
        }
    }
}

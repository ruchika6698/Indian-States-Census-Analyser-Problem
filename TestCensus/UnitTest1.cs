using NUnit.Framework;
using System;
using CensusAnalyzer;
using static CensusAnalyzer.StateCensusAnalyzer;
using static CensusAnalyzer.CSVStatesCensus;
using CensusAnalyser;
using Newtonsoft.Json.Linq;

namespace CensusAnalyzer
{
    public class Tests
    {
        GetCSVCount csvstatecensus = CSVFactory.DelegateofStateCensusAnalyse();
        GetCountFromCSVStates statesCodeCSV = CSVFactory.DelegateofStatecode();

        public string filepath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
        public string statecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.csv";
        public string jsonPathstateCensus = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.JSON";
        public string jsonPathstatecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusDatas\StateCode.JSON";

        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            int actual = csvstatecensus(filepath);
            Assert.AreEqual(30, actual);
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
            var incorrectDelimiter = Assert.Throws<CustomException>(() => csvstatecensus(filepath, '.'));
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            var incorrectHeader = Assert.Throws<CustomException>(() => csvstatecensus(filepath, ',', "St,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            int actual = statesCodeCSV(statecode);
            Assert.AreEqual(38, actual);
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
            var incorrectDelimiter = Assert.Throws<CustomException>(() => statesCodeCSV(filepath, '.'));
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-2.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            var incorrectHeader = Assert.Throws<CustomException>(() => statesCodeCSV(filepath, ',', "SrN,State,TIN,StateCode"));
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }
        /// <summary>
        /// Givens the first state of the CSV and json path to add into j son after sorting when analyse return.
        /// </summary>
        [Test]
        public void GivenCSVAndJsonPathToAddIntoJSon_AfterSorting_WhenAnalyse_ReturnFirstandLastState()
        {
            string firstValue = JSONCensus.SortCSVFileWriteInJsonAndReturnFirstData(filepath, jsonPathstateCensus, "State");
            Assert.AreEqual("Andhra Pradesh", firstValue);
            string lastValue = JSONCensus.SortCSVFileWriteInJsonAndReturnLastData(filepath, jsonPathstateCensus, "State");
            Assert.AreEqual("West Bengal", lastValue);
        }
    }
}

using NUnit.Framework;
using System;
using CensusAnalyzer;
using static CensusAnalyzer.StateCensusAnalyzer;
using static CensusAnalyzer.CSVStatesCensus;

namespace CensusAnalyzer
{
    public class Tests
    {
        CSVBuilder csvBuilder;
        GetCSVCount csvstatecensus = CSVFactory.DelegateofStateCensusAnalyse();
        GetCountFromCSVStates statesCodeCSV = CSVFactory.DelegateofStatecode();
        public string filepath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
        public string statecode = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.csv";
        
        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void GiventheStatesCensusCSVfile_WhenAnalyse_ShouldRecordNumberOfRecordmatches()
        {
            CSVBuilder csvBuilder = new CSVBuilder(filepath, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            int actual = csvstatecensus();
            Assert.AreEqual(30, actual);
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            CSVBuilder csvBuilder = new CSVBuilder(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensus.csv", ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            var actual = Assert.Throws<CustomException>(() => csvstatecensus());
            Assert.AreEqual("file path incorrect", actual.GetMessage);
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowCensusuAnalyserException()
        {
            CSVBuilder csvBuilder = new CSVBuilder(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.txt", ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            var incorrectpath = Assert.Throws<CustomException>(() => csvstatecensus());
            Assert.AreEqual("File type incorrect", incorrectpath.GetMessage);
        }
        /// <summary>
        ///TC-1.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            CSVBuilder csvBuilder = new CSVBuilder(filepath, ',', "State,Population,AreaInSqKm,DensityPerSqKm");
            var incorrectDelimiter = Assert.Throws<CustomException>(() => csvstatecensus());
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-1.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowCensusAnalyserException()
        {
            CSVBuilder csvBuilder = new CSVBuilder(filepath, ',', "Ste,Population,AreaInSqKm,DensityPerSqKm");
            var incorrectHeader = Assert.Throws<CustomException>(() => csvstatecensus());
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }

        /// <summary>
        ///TC-2.1: Test for checking number of Records in statecode csv
        /// </summary>
        [Test]
        public void GivenCSVStateCodeFile_WhenAnalyse_ShouldRecordNumberOfRecordmatcheStateCode()
        {
            CSVBuilder csvBuilder = new CSVBuilder(statecode, ',', "SrNo,State,TIN,StateCode");
            int actual = statesCodeCSV();
            Assert.AreEqual(38, actual);
        }
        /// <summary>
        ///TC-2.2:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfile_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            CSVBuilder csvBuilder = new CSVBuilder(@"C:\Users\boss\source\repos\CensusData\StateCode.csv", ',', "SrNo,State,TIN,StateCode");
            var actual = Assert.Throws<CustomException>(() => statesCodeCSV());
            Assert.AreEqual("file path incorrect", actual.GetMessage);
        }
        /// <summary>
        ///TC-2.3:If file incorrect then throw custom exception for statecode csv
        /// </summary>
        [Test]
        public void GivenIncorrectfileType_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            CSVBuilder csvBuilder = new CSVBuilder(@"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCode.txt", ',', "SrNo,State,TIN,StateCode");
            var incorrectpath = Assert.Throws<CustomException>(() => statesCodeCSV());
            Assert.AreEqual("File type incorrect", incorrectpath.GetMessage);
        }
        /// <summary>
        ///TC-2.4:csv file Correct but delimiter Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectDelimiter_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            CSVBuilder csvBuilder = new CSVBuilder(statecode, ',', "SrNo,State,TIN,StateCode");
            var incorrectDelimiter = Assert.Throws<CustomException>(() => statesCodeCSV());
            Assert.AreEqual("Incorrect Delimiter", incorrectDelimiter.GetMessage);
        }
        /// <summary>
        ///TC-2.5:csv file Correct but header Incorrect
        /// </summary>
        [Test]
        public void GivenIncorrectHeader_WhenAnalyse_ShouldThrowExceptionforstatecodeCSV()
        {
            CSVBuilder csvBuilder = new CSVBuilder(statecode, ',', "Sr,State,TIN,StateCode");
            var incorrectHeader = Assert.Throws<CustomException>(() => statesCodeCSV());
            Assert.AreEqual("Incorrect header", incorrectHeader.GetMessage);
        }

    }
}

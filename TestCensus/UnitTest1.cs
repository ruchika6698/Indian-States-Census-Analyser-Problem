using NUnit.Framework;
using CensusAnalyser;

namespace CensusAnalyser
{
    public class Tests
    {
        public string filepath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
        /// <summary>
        ///TC-1.1: Test for checking number of Records
        /// </summary>
        [Test]
        public void stateCensus_forCheckingnumberOfRecords()
        {
            Assert.AreEqual(30, StateCensusAnalyzer.records(filepath));
        }
        /// <summary>
        ///TC-1.2:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void stateCensus_ifFileincorrect()
        {
            string actualpath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
            Assert.AreEqual("File_not_found", StateCensusAnalyzer.numberOfRecords(actualpath));
        }
        /// <summary>
        ///TC-1.3:If file incorrect then throw custom exception
        /// </summary>
        [Test]
        public void stateCensus_TypeincorrectException()
        {
            string actualpath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.txt";
            Assert.AreEqual("File_format_Incorrect", StateCensusAnalyzer.numberOfRecords(actualpath));
        }
    }
}
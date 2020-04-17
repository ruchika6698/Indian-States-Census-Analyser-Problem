using NUnit.Framework;
using CensusAnalyser;

namespace CensusAnalyser
{
    public class Tests
    {
        public string filepath = @"C:\Users\boss\source\repos\CensusAnalyzerProblem\CensusData\StateCensusData.csv";
        [Test]
        public void stateCensus_forCheckingnumberOfRecords()
        {
            int numberofRecords = StateCensusAnalyzer.numberOfRecords(filepath);
            Assert.AreEqual(29,numberofRecords);
        }
    }
}
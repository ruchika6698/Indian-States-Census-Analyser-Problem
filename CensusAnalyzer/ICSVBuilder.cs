using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyzer
{
    public interface ICSVBuilder
    {
        public int numberOfRecords();
        public int getDataFromCSVFile();
    }
}
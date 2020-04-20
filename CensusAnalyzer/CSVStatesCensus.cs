using CensusAnalyser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    /// <summary>
    ///Method to find Number of records in file for StateCode csv file
    /// </summary>
    public class CSVStatesCensus
    {
        public static int getDataFromCSVFile(string statecode, char delimiter = ',', string header = "SrNo,State,TIN,StateCode")
        {
            int count = 0;
            try
            {
                if (Path.GetExtension(statecode) == ".csv")
                {
                    string[] data = File.ReadAllLines(statecode);
                    //check delimiter is correct or incorrect
                    foreach (string str in data)
                    {

                        if (str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                        {
                            throw new CustomException("Incorrect Delimiter");
                        }
                    }
                    //checking Incorrect header
                    if (!data[0].Equals(header))
                    {
                        throw new CustomException("Incorrect header");
                    }
                    IEnumerable<string> ele = data;
                    foreach (var elements in ele)
                    {
                        count++;
                    }
                    return count;
                }
                else                                                   //if file type incorrect then throw exception
                {
                    throw new CustomException("File type incorrect");
                }
            }
            catch (FileNotFoundException)                              //if file path incorrect then throw exception
            {
                throw new CustomException("file path incorrect");
            }
        }
    }
}

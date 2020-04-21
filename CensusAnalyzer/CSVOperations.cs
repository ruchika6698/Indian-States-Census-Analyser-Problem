using CensusAnalyzer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CensusAnalyzer
{
    /// <summary>
    ///class for csv file operations
    /// </summary>
    public class CSVOperations
    {
        /// <summary>
        ///Method to find Number of records in file for state census data
        /// </summary>
        public static int CountRecords(string[] records)
        {
            int count = 0;
            IEnumerable<string> enumerator = records;
            foreach (string str in enumerator)
            {
                count++;
            }
            return count;
        }
        /// <summary>
        ///Method to find file path is correct or incorrect
        /// </summary>
        public static string[] ReadCSVFile(string filepath)
        {
            try
            {
                string[] data = File.ReadAllLines(filepath);
                return data;
            }
            catch (FileNotFoundException)
            {
                throw new CustomException("file path incorrect");
            }
        }

        internal static int records()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///Method to find file type is correct or incorrect
        /// </summary>
        public static bool CheckFileType(string filepath, string type)
        {
            try
            {
                if (Path.GetExtension(filepath).Equals(type))
                {
                    return true;
                }
                throw new CustomException("File type incorrect");
            }
            catch (CustomException)
            {
                throw;
            }
        }
        /// <summary>
        ///Method to find file is correct but derimiter incorrect
        /// </summary>
        public static bool CheckForDelimiter(string[] fileData, char delimiter)
        {
            try
            {
                foreach (string str in fileData)
                {
                    if (str.Split(delimiter).Length != 5 && str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CustomException("Incorrect Delimiter");
                    }
                }
                return true;
            }
            catch (CustomException)
            {

                throw;
            }
        }
        /// <summary>
        ///Method to find file is correct but header incorrect
        /// </summary>
        public static bool CheckForHeader(string[] fileheader, string header)
        {
            try
            {
                if (fileheader[0].Equals(header))
                {
                    return true;
                }
                throw new CustomException("Incorrect header");
            }
            catch (CustomException)
            {
                throw;
            }
        }
    }
}

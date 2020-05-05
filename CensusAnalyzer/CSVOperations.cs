///-----------------------------------------------------------------
///   Class:       CSVOperations
///   Description: All methods are created for delimiter,count Records,Sorting etc.
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

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
        /// <param name="Path"> filepath </param>
        /// <returns> Number Of Records </returns>
        public static int NumberOfRecords(string path)
        {
            string[] array = File.ReadAllLines(path);
            return array.Length - 1;
        }

        /// <summary>
        ///Method to find Number of records in file for US Census data using map
        /// </summary>
        /// <param name="records"> number of records </param>
        /// <returns> Count Records for US census </returns>
        public static int CountRecords(string[] records)
        {
            int k = 1;
            //use mappung for store dataand value
            Dictionary<int, Dictionary<string, string>> map = new Dictionary<int, Dictionary<string, string>>();
            string[] key = records[0].Split(',');
            for (int i = 1; i < records.Length; i++)
            {
                string[] value = records[i].Split(',');
                Dictionary<string, string> subMap = new Dictionary<string, string>()
                {
                  { key[0], value[0] },
                  { key[1], value[1] },
                  { key[2], value[2] },
                  { key[3], value[3] },
                  { key[4], value[4] },
                  { key[5], value[5] },
                  { key[6], value[6] },
                  { key[7], value[7] },
                  { key[8], value[8] },
                };
                map.Add(k, subMap);
                k++;
            }
            return map.Count;
        }

        /// <summary>
        ///Method to find file path is correct or incorrect
        /// </summary>
        /// <param name="filepath"> filepath </param>
        /// <returns> File path incorrect </returns>
        public static string[] ReadCSVFile(string filepath)
        {
            //file path is incorrect then throw exception that File type incorrect
            try
            {
                string[] data = File.ReadAllLines(filepath);
                return data;
            }
            catch (FileNotFoundException)
            {
                throw new CustomException("file path incorrect", CustomException.ExceptionType.File_Path_Incorrect);
            }
        }

        /// <summary>
        ///Method to find file type is correct or incorrect
        /// </summary>
        /// <param name="filepath"> filepath </param>
        /// <param name="type"> filetype  </param>
        /// <returns> Wrong file Extention </returns>
        public static bool CheckFileType(string filepath, string type)
        {
            try
            {
                //file extention is not same then throw exception that File type incorrect
                if (Path.GetExtension(filepath).Equals(type))
                {
                    return true;
                }
                throw new CustomException("File type incorrect", CustomException.ExceptionType.File_Type_Incorrect);
            }
            catch (CustomException e)
            {
                throw e;
            }
        }

        /// <summary>
        ///Method to find file is correct but derimiter incorrect
        /// </summary>
        /// <param name="fileData"> fileData </param>
        /// <param name="delimiter"> delimiter  </param>
        /// <returns> check for delimiter </returns>
        public static bool CheckForDelimiter(string[] fileData, char delimiter)
        {
            try
            {
                foreach (string str in fileData)
                {
                    if (str.Split(delimiter).Length != 5 && str.Split(delimiter).Length != 4 && str.Split(delimiter).Length != 2)
                    {
                        throw new CustomException("Incorrect Delimiter", CustomException.ExceptionType.Incorrect_Delimiter);
                    }
                }
                return true;
            }
            catch (CustomException e)
            {
                throw e;
            }
        }
        /// <summary>
        ///Method to find file is correct but header incorrect
        /// </summary>
        /// <param name="fileheader"> fileheader </param>
        /// <param name="header"> header  </param>
        /// <returns> check for header </returns>
        public static bool CheckForHeader(string[] fileheader, string header)
        {
            try
            {
                //file header is not same then throw exception that header is incorrect
                if (fileheader[0].Equals(header))
                {
                    return true;
                }
                throw new CustomException("Incorrect header", CustomException.ExceptionType.Incorrect_Header);
            }
            catch (CustomException e)
            {
                throw e;
            }
        }

        /// <summary>
        ///Method for sorting
        /// </summary>
        /// <param name="jsonPath"> jsonPath </param>
        /// <param name="key"> key  </param>
        /// <returns> sorting </returns>
        public static JArray SortJsonBasedOnKey(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            //parsing a json file
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            //sorting in alphabatically
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if (stateCensusrrary[j][key].ToString().CompareTo(stateCensusrrary[j + 1][key].ToString()) > 0)
                    {
                        var temp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = temp;
                    }
                }
            }
            return stateCensusrrary;
        }

        /// <summary>
        ///Method for Find first state data from json file and sort alphabatically
        /// </summary>
        /// <param name="jsonPath"> jsonPath </param>
        /// <param name="key"> key  </param>
        /// <returns> Retrive First Data On Key </returns>
        public static string RetriveFirstDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            //Find First value in file wchich is alphabatically sorted
            string val = jArray[0][key].ToString();
            return val;
        }

        /// <summary>
        ///Method for Find Last test data from json file and sort alphabatically
        /// </summary>
        /// /// <param name="jsonPath"> jsonPath </param>
        /// <param name="key"> key  </param>
        /// <returns> Retrive Last Data On Key </returns>
        public static string RetriveLastDataOnKey(string jsonPath, string key)
        {
            string jfile = File.ReadAllText(jsonPath);
            JArray jArray = JArray.Parse(jfile);
            //Find last value in file which is alphabatically sorted
            string val = jArray[jArray.Count - 1][key].ToString();
            return val;
        }

        /// <summary>
        ///sorting for state population,Density and area
        /// </summary>
        /// <param name="jsonPath"> jsonPath </param>
        /// <param name="key"> key  </param>
        /// <returns> sort based on Key </returns>
        public static JArray SortJsonBasedOnKeyAndValueIsNumber(string jsonPath, string key)
        {
            string jsonFile = File.ReadAllText(jsonPath);
            //parsing a json file
            JArray stateCensusrrary = JArray.Parse(jsonFile);
            //sorting in sorting in ascending order
            for (int i = 0; i < stateCensusrrary.Count - 1; i++)
            {
                for (int j = 0; j < stateCensusrrary.Count - i - 1; j++)
                {
                    if ((int)stateCensusrrary[j][key] > (int)stateCensusrrary[j + 1][key])
                    {
                        var temp = stateCensusrrary[j + 1];
                        stateCensusrrary[j + 1] = stateCensusrrary[j];
                        stateCensusrrary[j] = temp;
                    }
                }
            }
            return stateCensusrrary;
        }
    }
}

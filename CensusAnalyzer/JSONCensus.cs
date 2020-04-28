///-----------------------------------------------------------------
///   Class:       JSONCensus
///   Description: CSV to JSON Conversion functions
///   Author:      Ruchika                   Date: 27/4/2020
///-----------------------------------------------------------------

using ChoETL;
using CensusAnalyzer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;

namespace CensusAnalyser
{
    public class JSONCensus
    {
        /// <summary>
        ///Method for sort First value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnFirstData(string path, string jsonFilepath, string key)
        {
            //create a object to read file
            string csvfile = File.ReadAllText(path);
            StringBuilder json = new StringBuilder();
            //read a csv file
            using (var p = ChoCSVReader.LoadText(csvfile)
                .WithFirstLineHeader()
                )
            {
                //write json file
                using (var w = new ChoJSONWriter(json))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, json.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, key);
            //convert into json format
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveFirstDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        ///Method for sort last value from json file
        /// </summary>
        public static string SortCSVFileWriteInJsonAndReturnLastData(string path, string jsonFilepath, string key)
        {
            //create a object to read file
            string csvfile = File.ReadAllText(path);
            StringBuilder json = new StringBuilder();
            //read a csv file
            using (var p = ChoCSVReader.LoadText(csvfile)
                .WithFirstLineHeader()
                )
            {
                //write json file
                using (var w = new ChoJSONWriter(json))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, json.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKey(jsonFilepath, key);
            //convert into json format
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, key);
        }
        /// <summary>
        ///sorting the state for population,density and area
        /// </summary>
        public static string SortCSVInJsonAndReturnData(string path, string jsonFilepath, string key)
        {
            //create a object to read file
            string csvfile = File.ReadAllText(path);
            StringBuilder json = new StringBuilder();
            //read a csv file
            using (var p = ChoCSVReader.LoadText(csvfile)
                .WithFirstLineHeader()
                )
            {
                //write json file
                using (var w = new ChoJSONWriter(json))
                    w.Write(p);
            }
            File.WriteAllText(jsonFilepath, json.ToString());
            JArray arr = CSVOperations.SortJsonBasedOnKeyAndValueIsNumber(jsonFilepath, key);
            //convert into json format
            var jsonArr = JsonConvert.SerializeObject(arr, Formatting.Indented);
            File.WriteAllText(jsonFilepath, jsonArr);

            return CSVOperations.RetriveLastDataOnKey(jsonFilepath, key);
        }
    }
}
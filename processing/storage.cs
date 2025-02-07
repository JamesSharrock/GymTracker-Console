using System;
using System.Data.SqlTypes;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.Json;
using System.Xml.Linq;
using WeightLiftingConsoleApp.Classes;
using WeightLiftingConsoleApp.Helper;

namespace WeightLiftingConsoleApp.Storage{
    class Store{
        public string GetLogPath(){
            string currentDirectory = Directory.GetCurrentDirectory();
            string upperDirectory = Path.Combine(currentDirectory, @"..\..\..");
            string logDirectory = Path.Combine(upperDirectory, "Logs");
            return logDirectory;
        }


        public void Save(Log log){
            string path = GetLogPath();
            Directory.CreateDirectory(path);
            string date = log.date.ToString("dd-MM-yyyy");
            string fileName = $"{date}_{log.title}.json";


            string filePath = Path.Combine(path, fileName);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(log, options);
            File.WriteAllText(filePath, jsonString);
            HelperLib.colourMessage("green", "File saved successfully");
        }

        public Log Load(DateTime date){
             string dateString = date.ToString("dd-MM-yyyy");
             string path = GetLogPath();
             string[] files = Directory.GetFiles(path, $"{dateString}*.json");

             //Load the first file from that date
             if (files.Length > 0) {
                 string filePath = files[0];
                 string jsonString = File.ReadAllText(filePath);
                 Log log = JsonSerializer.Deserialize<Log>(jsonString);
                 return log;
             }
            else{
                throw new FileNotFoundException("No file found at this date.");
            }
        }
        
        public void Delete(DateTime date){
             string dateString = date.ToString("dd-MM-yyyy");
             string path = GetLogPath();
             string[] files = Directory.GetFiles(path, $"{dateString}*.json");
            
             //Delete all Files from that date
             if (files.Length > 0){
                 foreach (string filePath in files){
                     File.Delete(filePath);
                     HelperLib.colourMessage("green", "File deleted successfully");
                 }
             }
             else{
                 HelperLib.colourMessage("red", "No file found at this date");
             }
        }

    }
}
using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using WeightLiftingConsoleApp.Helper;

namespace WeightLiftingConsoleApp.Classes{
    public class Log{
        public string title { get; set; }

        [JsonIgnore]
        public DateTime date { get; set; }
        public string FormattedDate => date.ToString("dd-MM-yyyy");
        public List<Exercise> exercises { get; set; }

        public Log(string title, DateTime date, List<Exercise> exercises){ //Constructor
            this.title = title;
            this.date = date;
            this.exercises = exercises;
        }

        public void printLog(){
            string printDate = date.ToString("dd-MM-yyyy");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            HelperLib.colourMessageLine("green", "\n"+new string('-', 20));
            HelperLib.colourMessageLine("green", $"Workout: {title} {printDate}");
            foreach (Exercise e in exercises){
                HelperLib.colourMessageLine("green", $"* {e.name}, {e.weight}(KG), {e.sets} sets, {e.reps} reps");
            }
            HelperLib.colourMessageLine("green", new string('-', 20));
        }

        
    }
}
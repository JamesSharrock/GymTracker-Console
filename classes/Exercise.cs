using System;
using System.Reflection.Metadata.Ecma335;

namespace WeightLiftingConsoleApp.Classes{
    public class Exercise{
        public string name { get; set; }
        public double weight {get; set; }
        public int sets {get; set; }
        public int reps { get; set; }
        
        public Exercise(string name, double weight, int sets, int reps){ //Constructor
            this.name = name;
            this.weight = weight;
            this.sets = sets;
            this.reps = reps;
        }
    }
}
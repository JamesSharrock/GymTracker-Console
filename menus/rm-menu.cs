using System;
using WeightLiftingConsoleApp.Helper;

namespace WeightLiftingConsoleApp.Menus{
    class RMMenu{
    
        public static void displayRMMenu(){
            HelperLib.colourMessage("yellow", "\n\nOne Rep Max Mode -");
            HelperLib.colourMessage("blue", new string('-', 20));
            displayRMInput();
            MainMenu.displayMainMenu();
            MainMenu.displayMainInput();
        }

        public static void displayRMInput(){
            HelperLib.colourMessage("cyan", "Enter Weight, Reps: ", false);
            string[] values = Console.ReadLine().Split(',');
            try{
                double weight = double.Parse(values[0]);
                int reps = Int32.Parse(values[1]);
                double oneRepMax = CalculateOneRM(weight, reps);
                HelperLib.colourMessage("green", $"One Rep Max: {oneRepMax}(KG)");
                HelperLib.colourMessage("blue", new string('-', 20));
            }
            catch (Exception){ //Validate can be correcly converted
                HelperLib.colourMessage("red", "Invalid input format");
                displayRMInput();
            }    
        }



        /* ----------------- Processing ------------------ */
        public static double CalculateOneRM(double weight, double reps){
            double oneRM = weight * (1 + (reps/30));
            oneRM = Math.Round(oneRM, 2);
            return oneRM;
        }
    }
}

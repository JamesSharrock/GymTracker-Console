using System;
using WeightLiftingConsoleApp.Helper;

namespace WeightLiftingConsoleApp.Menus{
    class BarbellMenu{
    
        public static void displayBarbellMenu(){
            HelperLib.colourMessage("yellow", "\n\nBarbell Weight Mode -");
            HelperLib.colourMessage("blue", new string('-', 20));
            displayBarbellInput();
            MainMenu.displayMainMenu();
            MainMenu.displayMainInput();
        }

        public static void displayBarbellInput(){
            HelperLib.colourMessage("cyan", "Enter Weight: ", false);
            string input = Console.ReadLine();

            try{
                double weight = double.Parse(input);
                List<string> results = CalculatePlates(weight);
                HelperLib.colourMessage("green", "Weight Each Side: ", false);
                foreach (string result in results){
                    HelperLib.colourMessage("green", $"\t {result}", false);
                }
                HelperLib.colourMessage("blue", "\n"+new string('-', 20));
            }
            catch (FormatException){ //Validate can be correcly converted
                HelperLib.colourMessage("red", "Invalid input format");
                displayBarbellInput();
            }             
        }



        /* ----------------- Processing ------------------ */
        public static List<string> CalculatePlates(double weight){
            var results = new List<string>();
            double barbell = 20;
            double oneSide = (weight - barbell)/2;
            double[] plates = [20, 15, 10, 5, 2.5, 1.25];
            foreach (double plate in plates){
                double amount = Math.Floor(oneSide / plate);
                if (amount > 0){
                    results.Add($"{plate}KG: {amount}");
                }
                oneSide -= plate * amount;
            }
            return results;
        }
    }
}
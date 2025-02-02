using System;
using WeightLiftingConsoleApp.Helper;

namespace WeightLiftingConsoleApp.Menus{
    class MainMenu{
    
        public static void Intro(){
            HelperLib.colourMessageLine("blue", "Gym Tracker Console App");
            displayMainMenu();
            displayMainInput();
        }

        public static void displayMainMenu(){
            HelperLib.colourMessageLine("yellow", "\n\nMenu -");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            HelperLib.colourMessageLine("yellow", "(1) - Log a Gym Session");
            HelperLib.colourMessageLine("yellow", "(2) - Calculate Barbell Weights");
            HelperLib.colourMessageLine("yellow", "(3) - Calculate 1RM");
            HelperLib.colourMessageLine("yellow", "(0) - Quit");
            HelperLib.colourMessageLine("blue", new string('-', 20));
        }

        public static void displayMainInput(){
            HelperLib.colourMessage("cyan", "Select a Mode: ");
            string ?mode = Console.ReadLine();
            if(mode == "0"){
                HelperLib.colourMessageLine("red", "Exiting the program");
                Environment.Exit(0);
            }
            switch(mode){
                case "1":
                    LogMenu.displayLogMenu();
                    break;
                case "2":
                    BarbellMenu.displayBarbellMenu();
                    break;
                case "3":
                    RMMenu.displayRMMenu();
                    break;
                default:
                    HelperLib.colourMessageLine("red", "Invalid selection. Please try again.");
                    displayMainInput();
                    break;
            }
        }
    }
}


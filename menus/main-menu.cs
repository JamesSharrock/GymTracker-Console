using System;
using WeightLiftingConsoleApp.Helper;

namespace WeightLiftingConsoleApp.Menus{
    class MainMenu{
    
        public static void Intro(){
            HelperLib.colourMessage("blue", "Gym Tracker Console App");
            displayMainMenu();
            displayMainInput();
        }

        public static void displayMainMenu(){
            HelperLib.colourMessage("yellow", "\n\nMenu -");
            HelperLib.colourMessage("blue", new string('-', 20));
            HelperLib.colourMessage("yellow", "(1) - Log a Gym Session");
            HelperLib.colourMessage("yellow", "(2) - Calculate Barbell Weights");
            HelperLib.colourMessage("yellow", "(3) - Calculate 1RM");
            HelperLib.colourMessage("yellow", "(0) - Quit");
            HelperLib.colourMessage("blue", new string('-', 20));
        }

        public static void displayMainInput(){
            HelperLib.colourMessage("cyan", "Select a Mode: ", false);
            string ?mode = Console.ReadLine();
            if(mode == "0"){
                HelperLib.colourMessage("red", "Exiting the program");
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
                    HelperLib.colourMessage("red", "Invalid selection. Please try again.");
                    displayMainInput();
                    break;
            }
        }
    }
}


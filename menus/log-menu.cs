using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using WeightLiftingConsoleApp.Classes;
using WeightLiftingConsoleApp.Helper;
using WeightLiftingConsoleApp.Storage;

namespace WeightLiftingConsoleApp.Menus{
    class LogMenu{
    
        public static void displayLogMenu(){
            HelperLib.colourMessageLine("yellow", "\n\nLogging Mode -");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            HelperLib.colourMessageLine("yellow", "(1) - New Log");
            HelperLib.colourMessageLine("yellow", "(2) - Load Log");
            HelperLib.colourMessageLine("yellow", "(3) - Delete Log");
            HelperLib.colourMessageLine("yellow", "(0) - Main Menu");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            displayLogInput();
        }

        public static void displayLogInput(){
            HelperLib.colourMessage("cyan", "Select a Mode: ");
            string ?mode = Console.ReadLine();
            if(mode == "0"){
                MainMenu.displayMainMenu();
                MainMenu.displayMainInput();
            }

            switch(mode){
                case "1":
                    newLog();
                    displayLogMenu();
                    displayLogInput();
                    break;
                case "2":
                    loadLog();
                    displayLogMenu();
                    displayLogInput();
                    break;
                case "3":
                    deleteLog();
                    displayLogMenu();
                    displayLogInput();
                    break;
                default:
                    HelperLib.colourMessageLine("red", "Invalid selection. Please try again.");
                    displayLogInput();
                    break;        
            }
        }


        /* ------------- New Log --------------*/
        public static void newLog(){
            HelperLib.colourMessageLine("yellow", "\n\nNew Log - ");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            string title = getTitle();
            DateTime date = getDate();
            List<Exercise> exercises = getExercises();
            Log newLog = new Log(title, date, exercises);
            newLog.printLog();
            Store storage = new Store();
            storage.Save(newLog);
        }
        /* ------------- Load Log --------------*/
        public static void loadLog(){
            HelperLib.colourMessageLine("yellow", "\n\nLoad Log - ");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            DateTime date = getDate();
            Store storage = new Store();
            try{
                Log log = storage.Load(date);
                log.printLog();
            }catch(FileNotFoundException ex){
                HelperLib.colourMessageLine("red", ex.Message);
            }
            
        }
        /* ------------- Delete Log --------------*/
        public static void deleteLog(){
            HelperLib.colourMessageLine("yellow", "\n\nDelete Log - ");
            HelperLib.colourMessageLine("blue", new string('-', 20));
            DateTime date = getDate();
            Store storage = new Store();
            try{
                Log log = storage.Load(date);
                log.printLog();
                storage.Delete(date);
            }catch(FileNotFoundException ex){
                HelperLib.colourMessageLine("red", ex.Message);
            }
            //Log log = storage.Load(date);
            HelperLib.colourMessageLine("red", "The following log has been deleted");
            //log.printLog();
            //storage.Delete(date);
        }
        





        /* ------------- Input Processing and Validation -------- */
        public static string getTitle(){
            HelperLib.colourMessage("cyan", "Enter Title: ");
            string ?title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) {
                HelperLib.colourMessageLine("red", "Title must not be empty.");
                return getTitle();
            }
            else{
                return title;
            }
        }
        public static DateTime getDate(){
            try{
                HelperLib.colourMessage("cyan", "Enter Date(dd/mm/yyyy): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                return date;
            } catch(Exception){
                HelperLib.colourMessageLine("red", "Invalid date format.");
                return getDate();
            } 
        }
        public static List<Exercise> getExercises(){
                var exercises = new List<Exercise>();
                int index;
                while (true){
                    try{
                        HelperLib.colourMessage("cyan", "Enter No. Exercises: ");
                        index = int.Parse(Console.ReadLine());
                        break;
                    }catch (Exception){
                        HelperLib.colourMessageLine("red", "Invalid number format.");
                    }

                }
                for (int i = 0; i <index; i++){
                    while (true){
                        try{
                            HelperLib.colourMessage("cyan", "Enter Name, Weights, Sets, Reps: ");
                            string[] values = Console.ReadLine().Split(',');
                            if (values.Length != 4) {
                                throw new FormatException("Invalid input format.");
                            }
                            Exercise newExercise = new Exercise(values[0], double.Parse(values[1]), int.Parse(values[2]), int.Parse(values[3]));
                            exercises.Add(newExercise);
                            break;        
                        }catch (FormatException ex){
                            HelperLib.colourMessageLine("red", ex.Message);
                        }catch (Exception){
                            HelperLib.colourMessageLine("red", "Incorrect exercise format.");
                        }
                    }
                }
            return exercises;
        }
    }
}

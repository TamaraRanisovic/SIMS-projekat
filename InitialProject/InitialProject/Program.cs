using InitialProject.Controller;
<<<<<<< Updated upstream
using Microsoft.Extensions.Hosting;
=======
using InitialProject.View;
>>>>>>> Stashed changes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject
{
    internal class Program
    {
        [STAThreadAttribute]

        public static void Main()
        {
<<<<<<< Updated upstream
            TourController TourController = new TourController();
=======
            var mainWindow = new LoginWindow();
            mainWindow.Show();

            // Run the WPF application
            var app = new App();
            app.Run();
            /*TourController TourController = new TourController();
>>>>>>> Stashed changes
            string chosenOption;
            do
            {
                WriteMenuOptions();
                chosenOption = Console.ReadLine();
                Console.Clear();
                ProcessChosenOption(chosenOption);
            } while (!chosenOption.Equals("x"));*/
            
        }

        private static void WriteMenuOptions()
        {
            Console.WriteLine("1. option A");
            Console.WriteLine("2. option B");
            Console.WriteLine("x. exit");
            Console.Write("Your option: ");
        }

        private static void ProcessChosenOption(string chosenOption) 
        {
            switch(chosenOption)
            {
                case "1":
                    Console.WriteLine("Chosen option: Prikaz i pretraga tura");
                    TourController TourController = new TourController();
                    TourController.GetMenu();
                    break; 
                case "2": 
                    Console.WriteLine("Chosen option: B");
                    break; 
<<<<<<< Updated upstream
=======
                case "3":
                    Console.WriteLine("Chosen option: 3");
                    AccomodationController accomodationController = new AccomodationController();
                    accomodationController.GetMenu();
                    break;
                case "4":
                    Console.WriteLine("Chosen option: 4");
                    Console.WriteLine("Chosen option: Prikaz i pretraga tura");
                    TourController TouristController = new TourController();
                    TouristController.GetMenu();
                    break;
>>>>>>> Stashed changes
                case "x":
                    break;
                default:
                    Console.WriteLine("Option does not exist"); 
                    break;
            }

        }
    }
}

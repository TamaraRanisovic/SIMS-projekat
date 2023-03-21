using InitialProject.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject
{
    internal class Program
    {
        [STAThreadAttribute]

        public static void Main()
        {
            string chosenOption;
            do
            {
                WriteMenuOptions();
                chosenOption = Console.ReadLine();
                Console.Clear();
                ProcessChosenOption(chosenOption);
            } while (!chosenOption.Equals("x"));
        }

        private static void WriteMenuOptions()
        {
            Console.WriteLine("1.idi do kontrolera");
            Console.WriteLine("2. option B");
            Console.WriteLine("x. exit");
            Console.Write("Your option: ");
        }

        private static void ProcessChosenOption(string chosenOption) 
        {
            
            switch(chosenOption)
            {
                case "1":
                    Console.WriteLine("Chosen option: A");
                    ControllerMenu controllerMenu = new ControllerMenu();
                    controllerMenu.Menu();
                    break; 
                case "2": 
                    Console.WriteLine("Chosen option: B"); 
                    break; 
                case "x":
                    break;
                default:
                    Console.WriteLine("Option does not exist"); 
                    break;
            }

        }
    }
}

﻿using InitialProject.Controller;
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

            Console.WriteLine("1.Owner's view");
            Console.WriteLine("2. Guide's view");
            Console.WriteLine("3. Guest's view");
            Console.WriteLine("4. Tourists's view");
            Console.WriteLine("x. exit");
            Console.Write("Your option: ");
        }

        private static void ProcessChosenOption(string chosenOption) 
        {
            
            switch(chosenOption)
            {
                case "1":
                    Console.WriteLine("Owner's view");
                    //ControllerMenu controllerMenu = new ControllerMenu();
                    //controllerMenu.Menu();

                    break; 
                case "2": 

                    Console.WriteLine("Chosen option: B"); 
                    break; 
                case "3":
                    Console.WriteLine("Guest's view");
                    break;
                case "4":
                    Console.WriteLine("Tourist's view");
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

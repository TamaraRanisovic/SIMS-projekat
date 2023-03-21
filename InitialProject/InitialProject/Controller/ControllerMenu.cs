using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebApi.Entities;

namespace InitialProject.Controller
{
    public class ControllerMenu
    {
        public ControllerMenu() { }

        public static readonly AccomodationService accomodationService = new AccomodationService();


        public void Menu()
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

        public void WriteMenuOptions()
        {
            Console.WriteLine("1. registruj smestaj i ubaci u bazu");
            Console.WriteLine("2. option B");
            Console.WriteLine("x. exit");
            Console.Write("Your option: ");
        }

        public static void ProcessChosenOption(string chosenOption)
        {
            switch (chosenOption)
            {
                case "1":
                    Accomodation accomodation = CreateAccomodation();
                    Location location = CreateLocation();
                    List<AccomodationImage> accomodationImages = CreateAccomodationImages();
                    accomodationService.RegisterAccomodation(accomodation, location, accomodationImages);
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

        public static Location CreateLocation()
        {

            string City;
            string Country;

            Console.Clear();
            Console.WriteLine("City:");
            City = Console.ReadLine();
            Console.WriteLine("Country:");
            Country = Console.ReadLine();

            Location newLocation = new Location(City, Country);

            return newLocation;
        }

        public static List<AccomodationImage> CreateAccomodationImages()
        {
   
            string Name;

            string URL;

            List<AccomodationImage> accomodationImages = new List<AccomodationImage>();

            Console.Clear();
            Console.WriteLine("Koliko vas smestaj ima slika(URL):");
            int numOfImages = Int32.Parse(Console.ReadLine());


            for (int i = 0; i < numOfImages; i++)
            {

                Console.Clear();
                Console.WriteLine("Image Name:");
                Name = Console.ReadLine();
                Console.WriteLine("URL:");
                URL = Console.ReadLine();

                AccomodationImage accomodationImage = new AccomodationImage(Name, URL);
                accomodationImages.Add(accomodationImage);

            }

            return accomodationImages;
        }

        public static Accomodation CreateAccomodation()
        {
            string name;
            Location location = new Location();
            AccomodationType accType;
            int maxGuests;
            int minReservationDays;
            int daysBeforeCanceling;


            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Enter AccomodationType value (Apartman, House, or Cabin):");
            string input = Console.ReadLine();
      
            bool isValid = Enum.TryParse(input, out accType);

            if (!isValid)
            {
                Console.WriteLine("Invalid AccomodationType value entered.");
            }
            else
            {
                string enumString = Enum.GetName(typeof(AccomodationType), accType);
                Console.WriteLine("You entered: " + enumString);
            }
            Console.Clear();

            Console.WriteLine("Maximum number of Guests:");
            maxGuests = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Minimum number of days for reservation:");
            minReservationDays = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Number of days before cancellation: ");
            daysBeforeCanceling = Int32.Parse(Console.ReadLine());
            Console.Clear();




            Accomodation newAccomodation = new Accomodation(name, location, accType, maxGuests, minReservationDays, daysBeforeCanceling);

            return newAccomodation;
        }
    }
}

using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Controller
{
    public class AccomodationController
    {
        public AccomodationService AccomodationService;

        public AccomodationController() { }

        public void GetMenu()
        {
            string chosenOption;
            do
            {
                Console.WriteLine("1. Show all accomodations");
                Console.WriteLine("2. Show accomodations by name [FULL PREWIEV]");
                Console.WriteLine("3. Show accomodations by location");
                Console.WriteLine("4. Show accomodations by type");
                Console.WriteLine("5. Show accomodations by number of guests");
                Console.WriteLine("6. Show accomodations by min days of reservation");
                Console.WriteLine("7. View available accomodations");
                Console.WriteLine("8. Reservate accomodation");
                Console.WriteLine("x - exit");
                chosenOption = Console.ReadLine();
                Console.Clear();

                switch (chosenOption)
                {
                    case "1":
                        Console.Clear();
                        GetAllAccomodations();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Name: ");
                        string name = Console.ReadLine();
                        GetByName(name);
                        break;
                    case "3":
                        Console.Clear();
                        string city, country;
                        Console.WriteLine("City: ");
                        city = Console.ReadLine();
                        Console.WriteLine("Country: ");
                        country = Console.ReadLine();
                        GetByLocation(city, country);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Type: ");
                        string type = Console.ReadLine();
                        GetByType(type);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("Number of guests: ");
                        int guestsNumber = int.Parse(Console.ReadLine());
                        GetByGuestsNumber(guestsNumber);
                        break;
                    case "6":
                        Console.Clear();
                        Console.WriteLine("Number of days reservation: ");
                        int reservationDays = int.Parse(Console.ReadLine());
                        GetByReservationDays(reservationDays);
                        break;

                    case "7":
                        Console.Clear();
                        Console.WriteLine("StartDate? (yyyy-MM-dd 12:00:00)");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("EndDate? (yyyy-MM-dd 12:00:00)");
                        DateTime end = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Number of guests?");
                        int numberOfGuests = int.Parse(Console.ReadLine());
                        FindAvailableAccomodations(start, end, numberOfGuests);
                        break;
                    
                        /*
                    case "8":
                        Console.Clear();

                        Console.WriteLine("Id acc?");
                        int id1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Guest id?");
                        int id2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("broj gosti");
                        int brojGosti = int.Parse(Console.ReadLine());

                        AccomodationService accomodationService = new AccomodationService();
                        UserService userService = new UserService();
                        Console.WriteLine("Username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password: ");
                        string password = Console.ReadLine();
                        if (userService.Login(username, password) != null)
                        {
                            Console.WriteLine("Chosen option: 1. Rezervisi turu");
                            Guest guests = (Guest)userService.GetByUsername(username);
                            accomodationService.BookAcc(id1, id2, brojGosti);
                            break;
                        }
                        break;
                        */
                }

            } while (!chosenOption.Equals("x"));
        }



        public void GetAllAccomodations()
        {
            AccomodationService accomodationService = new AccomodationService();
            AccomodationImagesService accomodationImagesService = new AccomodationImagesService();
            LocationService locationService = new LocationService();
            List<Accomodation> allAccomodations = accomodationService.GetAllAccomodations();
            List<AccomodationImage> accomodationImages = new List<AccomodationImage>();
            Location accomodationLocation = new Location();

            foreach (Accomodation accomodation in allAccomodations)
            {
                Console.WriteLine(accomodation.ToString());
                accomodationImages = accomodationImagesService.GetAccomodationImages(accomodation.AccId);
                foreach (AccomodationImage accomodationImage in accomodationImages)
                {
                    Console.WriteLine(accomodationImage);
                }
                accomodationLocation = accomodationService.GetAccomodationLocation(accomodation.AccId);
                Console.WriteLine(accomodationLocation);

            }
        }

        public void GetByName(string name)
        {
            AccomodationService accomodationService = new AccomodationService();
            AccomodationImagesService accomodationImagesService = new AccomodationImagesService();
            LocationService locationService = new LocationService();
            List<Accomodation> accomodationsByName = accomodationService.GetByName(name);
            List<AccomodationImage> accomodationImages = new List<AccomodationImage>();
            Location accomodationLocation = new Location();
            foreach (Accomodation accomodation in accomodationsByName)
            {
                Console.WriteLine(accomodation);
                accomodationImages = accomodationImagesService.GetAccomodationImages(accomodation.AccId);
                foreach (AccomodationImage accomodationImage in accomodationImages)
                {
                    Console.WriteLine(accomodationImage);
                }
                accomodationLocation = accomodationService.GetAccomodationLocation(accomodation.AccId);
                Console.WriteLine(accomodationLocation);
            }
        }

        public void GetByType(string type)
        {
            AccomodationService accomodationService = new AccomodationService();
            List<Accomodation> accomodationsByType = accomodationService.GetByType(type);
            foreach (Accomodation accomodation in accomodationsByType)
            {
                Console.WriteLine(accomodation);
            }
        }

        public void GetByLocation(string city, string country)
        {
            AccomodationService accomodationService = new AccomodationService();
            LocationService locationService = new LocationService();
            Location location = locationService.GetLocationByCityAndCountry(city, country);
            List<Accomodation> accomodationsByLocation = accomodationService.GetAccomodationsByLocation(location.LocationId);

            foreach (Accomodation accomodation in accomodationsByLocation)
            {
                Console.WriteLine(accomodation);
            }
        }


        public void GetByGuestsNumber(int guestsNumber)
        {
            AccomodationService accomodationService = new AccomodationService();
            List<Accomodation> accomodationsByGuestsNumber = accomodationService.GetByGuestsNumber(guestsNumber);
            foreach (Accomodation accomodation in accomodationsByGuestsNumber)
            {
                Console.WriteLine(accomodation);
            }
        }

        public void GetByReservationDays(int reservationDays)
        {
            AccomodationService accomodationService = new AccomodationService();
            List<Accomodation> accomodationsByReservationDays = accomodationService.GetByReservationDays(reservationDays);
            foreach (Accomodation accomodation in accomodationsByReservationDays)
            {
                Console.WriteLine(accomodation);
            }
        }

        public void FindAvailableAccomodations(DateTime start, DateTime end, int numberOfGuests)
        {
            AccomodationService accomodationService = new AccomodationService();
            List<Accomodation> accomodationsAvailable = accomodationService.FindAvailableAccomodations(start, end, numberOfGuests);
            foreach (Accomodation accomodation in accomodationsAvailable)
            {
                Console.WriteLine(accomodation);
            }
        }

        /*
        public void MakeReservation(int accId, int guestsId, DateTime startDate, DateTime endDate, int numberOfGuests)
        {
            AccomodationService accomodationService = new AccomodationService();

            Accomodation izabran = accomodationService.GetAccomodationById(accId);
            List<Accomodation> availableAccommodation = accomodationService.FindAvailableAccomodations(startDate, endDate, numberOfGuests);
            if (availableAccommodation == null)
            {

                throw new Exception("Nema.");
            }

            foreach (Accomodation accomodation in availableAccommodation)
            {
                if (accomodation == izabran)
                {
                    accomodationService.BookAcc(accId, guestsId, numberOfGuests);
                }
            }
            Accomodation selectedAccommodation = izabran;
            selectedAccommodation.IsAvailable = false;
        }
        */
    }
}

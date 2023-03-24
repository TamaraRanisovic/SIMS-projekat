using InitialProject.Model;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WebApi.Entities;

namespace InitialProject.Controller
{
    public class TouristController
    {

        TourService tourService = new TourService();
        TourImagesService tourImagesService = new TourImagesService();
        CheckpointService checkpointService = new CheckpointService();
        LocationService locationService = new LocationService();

        public TouristController()
        {
        }

        public void ShowToursByLocation()
        {
            string city, country;
            Console.WriteLine("City: ");
            city = Console.ReadLine();
            Console.WriteLine("Country: ");
            country = Console.ReadLine();

            GetToursByLocation(city, country);
        }

        public void ShowToursByDuration()
        {
            Console.WriteLine("Duration:");
            int duration = int.Parse(Console.ReadLine());

            GetToursByDuration(duration);
        }

        public void ShowToursByLanguage()
        {
            Console.WriteLine("Language:");
            string language = Console.ReadLine();

            GetToursByLanguage(language);
        }

        public void ShowToursByTouristsNumber()
        {
            Console.WriteLine("Tourists Number:");
            int tourists = int.Parse(Console.ReadLine());
            GetToursByTouristsNumber(tourists);
        }

        public void GetBookTourMenu()
        {
            ShowAllTours();

            Console.WriteLine("Izaberite koju turu zelite da rezervisete:\n");
            Console.WriteLine("TourId: ");
            int tourId = int.Parse(Console.ReadLine());
            Console.WriteLine("Number of Tourists: ");
            int tourists = int.Parse(Console.ReadLine());

            BookTour(tourId, tourists);
        }

        public void GetMenu()
        {
            string chosenOption;
            do
            {
                Console.WriteLine("1. Prikaz svih tura");
                Console.WriteLine("2. Prikaz tura po lokaciji");
                Console.WriteLine("3. Prikaz tura po trajanju ture");
                Console.WriteLine("4. Prikaz tura po jeziku");
                Console.WriteLine("5. Prikaz tura po broju turista");
                Console.WriteLine("6. Rezervisi turu");
                Console.WriteLine("x - izlazak iz programa");
                chosenOption = Console.ReadLine();
                Console.Clear();
                switch (chosenOption)
                {
                    case "1":
                        Console.WriteLine("Izabrana opcija: 1. Prikaz svih tura");
                        ShowAllTours();
                        break;
                    case "2":
                        Console.WriteLine("Chosen option: 2. Prikaz tura po lokaciji");
                        ShowToursByLocation();
                        break;
                    case "3":
                        Console.WriteLine("Izabrana opcija: 3. Prikaz tura po trajanju ture");
                        ShowToursByDuration();
                        Console.WriteLine("\n\n\n");
                        break;
                    case "4":
                        Console.WriteLine("Izabrana opcija: 4. Prikaz tura po jeziku");
                        ShowToursByLanguage();
                        Console.WriteLine("\n\n\n");
                        break;
                    case "5":
                        Console.WriteLine("Izabrana opcija: 5. Prikaz tura po broju turista");
                        ShowToursByTouristsNumber();
                        Console.WriteLine("\n\n\n");
                        break;
                    case "6":
                        Console.WriteLine("Izabrana opcija: 6. Rezervisi turu");
                        GetBookTourMenu();
                        Console.WriteLine("\n\n\n");
                        break;
                    default:
                        Console.WriteLine("Opcija ne postoji");
                        break;
                }
            } while (!chosenOption.Equals("x"));


        }

        public void ShowTour(Tour tour)
        {
            Console.WriteLine(tour);

            List<TourImages> tourImages = tourImagesService.GetTourImages(tour.TourId);
            foreach (TourImages tourImage in tourImages)
            {
                Console.WriteLine(tourImage);
            }

            Location tourLocation = tourService.GetTourLocation(tour.TourId);
            Console.WriteLine(tourLocation);

            List<Checkpoint> tourCheckpoints = checkpointService.GetTourCheckpoints(tour.TourId);
            foreach (Checkpoint checkpoint in tourCheckpoints)
            {
                Console.WriteLine(checkpoint);
            }

        }

        public void ShowAllTours()
        {
            List<Tour> allTours = tourService.GetAllTours();
            
            foreach (Tour tour in allTours)
            {
                ShowTour(tour);
            }
        }

        public void GetToursByLocation(string city, string country)
        {

            Location location = locationService.GetLocationByCityAndCountry(city, country);
            List<Tour> toursByLocation = tourService.GetToursByLocation(location.LocationId);

            foreach (Tour tour in toursByLocation)
            {
                ShowTour(tour);
            }
        }

        public void GetToursByDuration(int duration)
        {
            List<Tour> toursByDuration = tourService.GetToursByDuration(duration);
            
            foreach (Tour tour in toursByDuration)
            {
                ShowTour(tour);
            }
        }

        public void GetToursByLanguage(string language)
        {

            List<Tour> toursByLanguage = tourService.GetToursByLanguage(language);

            foreach (Tour tour in toursByLanguage)
            {
                ShowTour(tour);
            }
        }

        public void GetToursByTouristsNumber(int tourists)
        {

            List<Tour> toursByGuestsNumber = tourService.GetToursByTouristsNumber(tourists);

            foreach (Tour tour in toursByGuestsNumber)
            {
                ShowTour(tour);
            }
        }

        public bool HasFreeSpots(int tourId, int touristsNumber)
        {
            Tour tour = tourService.GetTourById(tourId);

            if (tourService.GetFreeSpotsNumber(tourId) < touristsNumber)
            {
                Console.WriteLine("Na izabranoj turi nema slobodnih mesta.");

                Location location = tourService.GetTourLocation(tourId);

                Console.WriteLine("Ture na istoj lokaciji: ");                
                GetToursByLocation(location.City, location.Country);

                return false;
            }

            Console.WriteLine("Broj slobodnih mesta: ");
            Console.WriteLine(tourService.GetFreeSpotsNumber(tourId));

            return true;
        }

        public bool BookOrExit(int tourId, int tourists)
        {
            UserService userService = new UserService();

            string chosenOption;

            do
            {
                Console.WriteLine("Izaberite jednu od opcija: ");
                Console.WriteLine("1. Rezervisi turu");
                Console.WriteLine("x - Izlazak iz programa");
                chosenOption = Console.ReadLine();
                Console.Clear();

                if (chosenOption.Equals("1"))
                {
                    Console.WriteLine("Izabrana opcija: 1. Rezervisi turu");

                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();

                    if (userService.Login(username, password) != null)
                    {
                        Tourist tourist = (Tourist)userService.GetByUsername(username);
                        tourService.BookTour(tourId, tourist.Id, tourists);

                        return true;
                    }
                }
            } while (!chosenOption.Equals("x"));

            return false;
        }

        public bool ChangeTouristsNumber(int tourId)
        {
            Console.WriteLine("Number of Tourists: ");
            int tourists = int.Parse(Console.ReadLine());

            if (HasFreeSpots(tourId, tourists))
            {
                return BookOrExit(tourId, tourists);
            }
            return false;
        }
        public bool BookTour(int tourId, int tourists)
        {
            if (HasFreeSpots(tourId, tourists)) {
                return BookOrExit(tourId, tourists);
            }

            string chosenOption;

            {
                do
                {
                    Console.WriteLine("Izaberite jednu od opcija: ");
                    Console.WriteLine("1. Izmena broja turista");
                    Console.WriteLine("2. Odabir druge ture na istoj lokaciji");
                    Console.WriteLine("x. Izlazak iz programa");
                    chosenOption = Console.ReadLine();
                    Console.Clear();

                    switch (chosenOption)
                    {
                        case "1":
                            Console.WriteLine("Izabrana opcija: 1. Izmena broja turista");
                            ChangeTouristsNumber(tourId);
                            break;
                        case "2":
                            Console.WriteLine("Izabrana opcija: 2.  Odabir druge ture na istoj lokaciji");
                            Location location = tourService.GetTourLocation(tourId);
                            GetToursByLocation(location.City, location.Country);

                            List<Tour> toursByLocation = tourService.GetToursByLocation(location.LocationId);
                            Console.WriteLine("Odaberite jednu od ponudjenih tura koje su na istoj lokaciji: ");

                            Console.WriteLine("TourId: ");
                            int newTourId = int.Parse(Console.ReadLine());
                            Tour chosenTour = tourService.GetTourById(newTourId);

                            int b = 0;
                            foreach (Tour tour in toursByLocation)
                            {
                                if (tour.TourId == newTourId)
                                {
                                    b++;
                                }
                            }
                            if (b == 0)
                            {
                                Console.WriteLine("Izabrana tura nije na istoj lokaciji");
                                break;
                            }
                            if (ChangeTouristsNumber(chosenTour.TourId))
                            {
                                return true; 
                            }  
                            
                            break;
                        default:
                            Console.WriteLine("Opcija ne postoji");
                            break;
                    }
                } while (!chosenOption.Equals("x"));
            }
            return false;
        }
    }
}

using InitialProject.Model;
using InitialProject.Service;
using Microsoft.AspNetCore.Mvc;
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
    public class TourController
    {
        public TourService TourService;

        public CheckpointService CheckpointService;

        //public static readonly TourService tourService = new TourService();

        public TourController()
        {
            //TourService = new TourService();
        }
        /*public TourController(TourService tourService)
        {
            TourService = tourService;
        }*/

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
                        Console.WriteLine("Chosen option: 1. Prikaz svih tura");
                        Console.Clear();
                        GetAllTours();
                        break;
                    case "2":
                        Console.WriteLine("Chosen option: 2. Prikaz tura po lokaciji");

                        string city, country;
                        Console.WriteLine("City: ");
                        city = Console.ReadLine();
                        Console.WriteLine("Country: ");
                        country = Console.ReadLine();
                        GetByLocation(city, country);
                        break;
                    case "3":
                        Console.WriteLine("Chosen option: 3. Prikaz tura po trajanju ture");
                        Console.WriteLine("Duration:");
                        int duration = int.Parse(Console.ReadLine());
                        GetByDuration(duration);
                        Console.WriteLine("\n\n\n");
                        break;
                    case "4":
                        Console.WriteLine("Chosen option: 4. Prikaz tura po jeziku");
                        Console.WriteLine("Language:");
                        string language = Console.ReadLine();
                        GetByLanguage(language);
                        Console.WriteLine("\n\n\n");

                        break;
                    case "5":
                        Console.WriteLine("Chosen option: 5. Prikaz tura po broju turista");
                        Console.WriteLine("Guests Number:");
                        int guestsNumber = int.Parse(Console.ReadLine());
                        GetByGuestsNumber(guestsNumber);
                        Console.WriteLine("\n\n\n");
                        break;
                    case "6":
                        Console.WriteLine("Chosen option: 6. Rezervisi turu");
                        GetAllTours();
                        Console.WriteLine("Izaberite koju turu zelite da rezervisete:\n");
                        Console.WriteLine("TourId: ");
                        int tourId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Number of Tourists: ");
                        int touristsNumber = int.Parse(Console.ReadLine());
                        BookATour(tourId, touristsNumber);
                        Console.WriteLine("\n\n\n");
                        break;
                    default:
                        Console.WriteLine("Option does not exist");
                        break;
                }
            } while (!chosenOption.Equals("x"));


        }
        public void GetAllTours()
        {
            TourService tourService = new TourService();
            TourImagesService tourImagesService = new TourImagesService();
            CheckpointService checkpointService = new CheckpointService();
            LocationService locationService = new LocationService();
            List<Tour> allTours = tourService.GetAllTours();
            List<TourImages> tourImages = new List<TourImages>();
            List<Checkpoint> tourCheckpoints = new List<Checkpoint>();
            Location tourLocation = new Location();
            List<Tourist> tourTourists = new List<Tourist>();
            foreach (Tour tour in allTours)
            {
                Console.WriteLine(tour.ToString());
                tourImages = tourImagesService.GetTourImages(tour.TourId);
                foreach (TourImages tourImage in tourImages)
                {
                    Console.WriteLine(tourImage);
                }
                tourLocation = tourService.GetTourLocation(tour.TourId);
                Console.WriteLine(tourLocation);
                tourCheckpoints = checkpointService.GetTourCheckpoints(tour.TourId);
                foreach (Checkpoint checkpoint in tourCheckpoints)
                {
                    Console.WriteLine(checkpoint);
                }
                tourTourists = tourService.GetTourists(tour.TourId);
                Console.WriteLine(tourTourists.Count());
                foreach (Tourist tourist in tourTourists)
                {
                    Console.WriteLine(tourist);
                }
                Console.WriteLine("Number of free spots: ");
                Console.WriteLine(tourService.GetFreeSpotsNumber(tour.TourId));

            }


        }

        public void GetByLocation(string city, string country)
        {
            TourService tourService = new TourService();
            TourImagesService tourImagesService = new TourImagesService();
            CheckpointService checkpointService = new CheckpointService();

            LocationService locationService = new LocationService();
            Location location = locationService.GetLocationByCityAndCountry(city, country);
            List<Tour> toursByLocation = tourService.GetToursByLocation(location.LocationId);
            List<TourImages> tourImages = new List<TourImages>();
            Location tourLocation = new Location();
            List<Checkpoint> tourCheckpoints = new List<Checkpoint>();

            foreach (Tour tour in toursByLocation)
            {
                Console.WriteLine(tour);
                tourImages = tourImagesService.GetTourImages(tour.TourId);
                foreach (TourImages tourImage in tourImages)
                {
                    Console.WriteLine(tourImage);
                }
                tourLocation = tourService.GetTourLocation(tour.TourId);
                Console.WriteLine(tourLocation);
                tourCheckpoints = checkpointService.GetTourCheckpoints(tour.TourId);
                foreach (Checkpoint checkpoint in tourCheckpoints)
                {
                    Console.WriteLine(checkpoint);
                }
            }
        }

        public void GetByDuration(int duration)
        {
            TourService tourService = new TourService();
            List<Tour> toursByDuration = tourService.GetByDuration(duration);
            TourImagesService tourImagesService = new TourImagesService();
            CheckpointService checkpointService = new CheckpointService();
            List<TourImages> tourImages = new List<TourImages>();
            Location tourLocation = new Location();
            List<Checkpoint> tourCheckpoints = new List<Checkpoint>();
            foreach (Tour tour in toursByDuration)
            {
                Console.WriteLine(tour);
                tourImages = tourImagesService.GetTourImages(tour.TourId);
                foreach (TourImages tourImage in tourImages)
                {
                    Console.WriteLine(tourImage);
                }
                tourLocation = tourService.GetTourLocation(tour.TourId);
                Console.WriteLine(tourLocation);
                tourCheckpoints = checkpointService.GetTourCheckpoints(tour.TourId);
                foreach (Checkpoint checkpoint in tourCheckpoints)
                {
                    Console.WriteLine(checkpoint);
                }
            }
        }

        public void GetByLanguage(string language)
        {
            TourService tourService = new TourService();
            TourImagesService tourImagesService = new TourImagesService();
            CheckpointService checkpointService = new CheckpointService();
            List<Tour> toursByLanguage = tourService.GetByLanguage(language);
            List<TourImages> tourImages = new List<TourImages>();
            Location tourLocation = new Location();
            List<Checkpoint> tourCheckpoints = new List<Checkpoint>();
            foreach (Tour tour in toursByLanguage)
            {
                Console.WriteLine(tour);
                tourImages = tourImagesService.GetTourImages(tour.TourId);
                foreach (TourImages tourImage in tourImages)
                {
                    Console.WriteLine(tourImage);
                }
                tourLocation = tourService.GetTourLocation(tour.TourId);
                Console.WriteLine(tourLocation);
                tourCheckpoints = checkpointService.GetTourCheckpoints(tour.TourId);
                foreach (Checkpoint checkpoint in tourCheckpoints)
                {
                    Console.WriteLine(checkpoint);
                }
            }
        }

        public void GetByGuestsNumber(int guestsNumber)
        {
            TourService tourService = new TourService();
            TourImagesService tourImagesService = new TourImagesService();
            CheckpointService checkpointService = new CheckpointService();
            List<Tour> toursByGuestsNumber = tourService.GetByGuestsNumber(guestsNumber);
            List<TourImages> tourImages = new List<TourImages>();
            Location tourLocation = new Location();
            List<Checkpoint> tourCheckpoints = new List<Checkpoint>();
            foreach (Tour tour in toursByGuestsNumber)
            {
                Console.WriteLine(tour);
                tourImages = tourImagesService.GetTourImages(tour.TourId);
                foreach (TourImages tourImage in tourImages)
                {
                    Console.WriteLine(tourImage);
                }
                tourLocation = tourService.GetTourLocation(tour.TourId);
                Console.WriteLine(tourLocation);
                tourCheckpoints = checkpointService.GetTourCheckpoints(tour.TourId);
                foreach (Checkpoint checkpoint in tourCheckpoints)
                {
                    Console.WriteLine(checkpoint);
                }
            }
        }

        public bool HasFreeSpots(int tourId, int touristsNumber)
        {
            TourService tourService = new TourService();
            Tour tour = tourService.GetTourById(tourId);
            if (tourService.GetFreeSpotsNumber(tourId) < touristsNumber)
            {
                Console.WriteLine("Na izabranoj turi nema slobodnih mesta.");
                Location location = tourService.GetTourLocation(tourId);
                List<Tour> toursByLocation = tourService.GetToursByLocation(location.LocationId);
                Console.WriteLine("Broj tura na istoj lokaciji: ");
                Console.WriteLine(toursByLocation.Count());
                foreach (Tour tourByLocation in toursByLocation)
                {
                    Console.WriteLine(tourByLocation);
                }
                return false;
            }
            Console.WriteLine("Broj slobodnih mesta: ");
            Console.WriteLine(tourService.GetFreeSpotsNumber(tourId));
            return true;
        }

        public bool BookOrExit(int tourId, int touristsNumber)
        {
            TourService tourService = new TourService();
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
                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = Console.ReadLine();
                    if (userService.Login(username, password) != null) {
                        Console.WriteLine("Chosen option: 1. Rezervisi turu");
                        Tourist tourist = (Tourist)userService.GetByUsername(username);
                        tourService.BookATour(tourId, tourist.Id, touristsNumber);
                        break;
                    }
                    
                }
            } while (!chosenOption.Equals("x"));
            return false;
             
        }

        public bool BookATour(int tourId, int touristsNumber)
        {
            TourService tourService = new TourService();

            if (HasFreeSpots(tourId, touristsNumber)) {
                return BookOrExit(tourId, touristsNumber);
            }
            string chosenOption;

            {
                string option;
                do
                {
                    Console.WriteLine("Izaberite jednu od opcija: ");
                    Console.WriteLine("1. Izmena broja turista");
                    Console.WriteLine("2. Odabir druge ture na istoj lokaciji");
                    Console.WriteLine("x. Izlazak iz programa");
                    option = Console.ReadLine();
                    Console.Clear();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Chosen option: 1. Izmena broja turista");
                            Console.WriteLine("Number of Tourists: ");
                            touristsNumber = int.Parse(Console.ReadLine());
                            if (HasFreeSpots(tourId, touristsNumber))
                            {
                                return BookOrExit(tourId, touristsNumber);
                            }
                            break;
                        case "2":
                            Console.WriteLine("Chosen option: 2.  Odabir druge ture na istoj lokaciji");
                            Location location = tourService.GetTourLocation(tourId);
                            List<Tour> toursByLocation = tourService.GetToursByLocation(location.LocationId);
                            Console.WriteLine("Odaberite jednu od ponudjenih tura koje su na istoj lokaciji: ");
                            foreach (Tour tour in toursByLocation)
                            {
                                Console.WriteLine(tour);
                            }
                            Console.WriteLine("TourId: ");
                            int newTourId = int.Parse(Console.ReadLine());
                            Tour chosenTour = tourService.GetTourById(newTourId);
                            Console.WriteLine(chosenTour);
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
                            Console.WriteLine("TouristsNumber: ");
                            touristsNumber = int.Parse(Console.ReadLine());
                            if (HasFreeSpots(newTourId, touristsNumber))
                            {
                                return BookOrExit(newTourId, touristsNumber);
                            }

                            break;
                        default:
                            break;
                    }
                } while (!option.Equals("x"));
            }
            return false;
        }
    }
}

using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class TourService
    {


        private readonly TourRepository TourRepository;

        private readonly LocationRepository LocationRepository;

        private readonly TourImagesRepository TourImagesRepository;


        public TourService() {

        }

<<<<<<< Updated upstream
        public TourService(TourRepository tourRepository, LocationRepository locationRepository)
        {
            TourRepository = tourRepository;
            LocationRepository = locationRepository;
        }

        public List<Tour> GetAllTours()
        {
            TourRepository tourRepository = new TourRepository();
            return tourRepository.GetAllTours();
=======
        public List<Tour> GetAll()
        {
            return tourRepository.GetAll();
>>>>>>> Stashed changes
        }

        public Tour GetById(int tourId)
        {
<<<<<<< Updated upstream
            TourRepository tourRepository = new TourRepository();
            return tourRepository.GetTourById(tourId);
=======
            return tourRepository.GetById(tourId);
>>>>>>> Stashed changes
        }

        public List<Tour> GetAllByLocation(int locationId)
        {
<<<<<<< Updated upstream
            TourRepository tourRepository = new TourRepository();
            //List<Location> allLocations = locationRepository.GetAllLocations();
            List<Tour> toursByLocation = tourRepository.GetToursByLocation(locationId);
            return toursByLocation;

        }

        public List<Tour> GetByDuration(int duration)
        {
            TourRepository tourRepository = new TourRepository();
            List<Tour> allTours = tourRepository.GetAllTours();
=======
            return tourRepository.GetAllByLocation(locationId);
        }

        public List<Tour> GetAllByDuration(int duration)
        {
            List<Tour> allTours = tourRepository.GetAll();
>>>>>>> Stashed changes
            List<Tour> toursByDuration = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Duration == duration)
                {
                    toursByDuration.Add(tour);
                }
            }

            return toursByDuration;
        }

<<<<<<< Updated upstream
        public List<Tour> GetByLanguage(string language)
        {
            TourRepository tourRepository = new TourRepository();
            List<Tour> allTours = tourRepository.GetAllTours();
=======
        public List<Tour> GetAllByLanguage(string language)
        {
            List<Tour> allTours = tourRepository.GetAll();
>>>>>>> Stashed changes
            List<Tour> toursByLanguage = new List<Tour>();

            foreach (Tour tour in allTours)
            {
                if (tour.Language.Equals(language))
                {
                    toursByLanguage.Add(tour);
                }
            }

            return toursByLanguage;
        }
<<<<<<< Updated upstream
        public List<Tour> GetByGuestsNumber(int guestsNumber)
        {
            TourRepository tourRepository = new TourRepository();
            List<Tour> allTours = tourRepository.GetAllTours();
            List<Tour> toursByGuestsNumber = new List<Tour>();
=======
        public List<Tour> GetAllByTouristsNumber(int tourists)
        {
            List<Tour> allTours = tourRepository.GetAll();
            List<Tour> toursByTouristsNumber = new List<Tour>();
>>>>>>> Stashed changes

            foreach (Tour tour in allTours)
            {
                if (tour.Tourists != null)
                {
                    if (tour.MaxGuests - tour.Tourists.Count() >= guestsNumber)
                    {
                        toursByGuestsNumber.Add(tour);
                    }
                } else
                {
                    if (tour.MaxGuests >= guestsNumber)
                    {
                        toursByGuestsNumber.Add(tour);
                    }
                }
            }

            return toursByGuestsNumber;
        }

        public Location GetTourLocation(int tourId)
        {
            LocationRepository locationRepository = new LocationRepository();

            List<Location> allLocations = locationRepository.GetAllLocations();
            List<Tour> toursByLocation = new List<Tour>();

            foreach (Location location in allLocations)
            {
                toursByLocation = GetAllByLocation(location.LocationId);
                foreach (Tour tour in toursByLocation)
                {
                    if (tour.TourId == tourId)
                    {
                        return location;
                    }
                }
            }
            return null;

        }

        public List<Tourist> GetTourists(int tourId)
        {
            TouristsRepository touristsRepository = new TouristsRepository();
            return touristsRepository.GetTourists(tourId);
        }

        public int GetFreeSpotsNumber(int tourId)
        {
<<<<<<< Updated upstream
            TourRepository tourRepository = new TourRepository();
            Tour tour = GetTourById(tourId);
            List<Tourist> tourTourists = new List<Tourist>();
            tourTourists = GetTourists(tourId);
            int freeSpotsNumber = tour.MaxGuests - tourRepository.GetNumberOfTouristsInATour(tourId);
=======
            Tour tour = GetById(tourId);
            List<Tourist> tourTourists = GetTourists(tourId);
            int freeSpotsNumber = tour.MaxGuests - tourRepository.GetTouristsNumber(tourId);
>>>>>>> Stashed changes
            return freeSpotsNumber;
        }

        public void BookATour(int tourId, int touristId, int touristsNumber)
        { 
            TourRepository tourRepository = new TourRepository();
            tourRepository.BookATour(tourId, touristId, touristsNumber);
        }

<<<<<<< Updated upstream
=======
        public void MakeTour(Tour tour, Location location, List<TourImages> tourImages, List<Checkpoint> checkpoints)
        {       

            using (var context = new DataContext())
            {
                
                Location existingLocation = locationRepository.GetByCityAndCountry(location.City, location.Country);
                
                

                if (existingLocation != null)
                {
                    location = existingLocation;
                    location.Tours.Add(tour);
                    context.Locations.Update(location);
                }
                else
                {
                    location.Tours.Add(tour);
                    context.Locations.Add(location);
                }

                foreach (var image in tourImages)
                {
                    context.TourImages.Add(image);
                    tour.Images.Add(image);
                }

                foreach (var checkpoint in checkpoints)
                {
                    context.Checkpoints.Add(checkpoint);
                    tour.Checkpoints.Add(checkpoint);
                }

                

                context.SaveChanges();
            }
        }

        public void TourTracking()
        {
            
            using (var context = new DataContext())
            {
                TourRepository tourRepository = new TourRepository();
                DateTime danasnjiDatum = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0 , 0 , 0);
                Console.WriteLine("Danasnji datum: " + danasnjiDatum);
                List<Tour> todaysTours = tourRepository.GetToursByStartDate(danasnjiDatum);
              
                string trackingTourName = FindTodaysToursName();

                Tour trackingTour = new Tour();

                trackingTour = startTrackingTour(trackingTourName, todaysTours);
                if(trackingTour == null) 
                {
                    Console.WriteLine("Tura sa tim imenom ne postoji ili nije na danasnjem programu");
                    return;
                }
                context.SaveChanges();
                ShowCheckpoints(trackingTour);

                Menu(trackingTour);
>>>>>>> Stashed changes



    }
}

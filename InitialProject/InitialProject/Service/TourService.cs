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

        public TourService(TourRepository tourRepository, LocationRepository locationRepository)
        {
            TourRepository = tourRepository;
            LocationRepository = locationRepository;
        }

        public List<Tour> GetAllTours()
        {
            TourRepository tourRepository = new TourRepository();
            return tourRepository.GetAllTours();
        }

        public Tour GetTourById(int tourId)
        {
            TourRepository tourRepository = new TourRepository();
            return tourRepository.GetTourById(tourId);
        }

        public List<Tour> GetToursByLocation(int locationId)
        {
            TourRepository tourRepository = new TourRepository();
            //List<Location> allLocations = locationRepository.GetAllLocations();
            List<Tour> toursByLocation = tourRepository.GetToursByLocation(locationId);
            return toursByLocation;

        }

        public List<Tour> GetByDuration(int duration)
        {
            TourRepository tourRepository = new TourRepository();
            List<Tour> allTours = tourRepository.GetAllTours();
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

        public List<Tour> GetByLanguage(string language)
        {
            TourRepository tourRepository = new TourRepository();
            List<Tour> allTours = tourRepository.GetAllTours();
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
        public List<Tour> GetByGuestsNumber(int guestsNumber)
        {
            TourRepository tourRepository = new TourRepository();
            List<Tour> allTours = tourRepository.GetAllTours();
            List<Tour> toursByGuestsNumber = new List<Tour>();

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
                toursByLocation = GetToursByLocation(location.LocationId);
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
            Tour tour = GetTourById(tourId);
            List<Tourist> tourTourists = new List<Tourist>();
            tourTourists = GetTourists(tourId);
            int freeSpotsNumber = tour.MaxGuests - tourTourists.Count();
            return freeSpotsNumber;
        }

        public void BookATour(int tourId, int touristId, int touristsNumber)
        { 
            TourRepository tourRepository = new TourRepository();
            tourRepository.BookATour(tourId, touristId, touristsNumber);

        }




    }
}

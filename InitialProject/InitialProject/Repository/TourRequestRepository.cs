using InitialProject.DTO;
using InitialProject.Interfaces;
using InitialProject.Model;
using InitialProject.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class TourRequestRepository : ITourRequestRepository
    {
        public void Add(TourRequest tourRequest, int touristId, int guideId)
        {
            using (var db = new DataContext())
            {
                tourRequest.RequestDate = DateTime.Now;
                db.TourRequests.Add(tourRequest);
                Tourist loggedInTourist = db.Tourists.Find(touristId);
                Guide guide = db.Guides.Find(guideId);
                loggedInTourist.TourRequests.Add(tourRequest);
                guide.TourRequests.Add(tourRequest);
                db.SaveChanges();
            }
        }

        public List<TourRequest> GetAll()
        {
            using (var db = new DataContext())
            {
                ChangeTourRequestStatus();
                return db.TourRequests.ToList();
            }
        }

        public List<TourRequest> GetAllByLocation(Location location)
        {
            using (var db = new DataContext())
            {
                return db.TourRequests.Where(t => t.City == location.City && t.Country == location.Country).ToList();
            }
        }

        public List<TourRequest> GetAllByLanguage(string language)
        {
            using (var db = new DataContext())
            {
                return db.TourRequests.Where(t => t.Language == language).ToList();
            }
        }

        public List<TourRequest> GetAllByYear(int year)
        {
            using (var db = new DataContext())
            {
                return db.TourRequests.Where(t => t.RequestDate.Year == year).ToList();
            }
        }

        public List<TourRequest> GetAllByYearAndMonth(int year, int month)
        {
            using (var db = new DataContext())
            {
                return db.TourRequests.Where(t => t.StartDate.Year == year && t.StartDate.Month == month).ToList();
            }
        }

        public List<TourRequest> GetAllByNumOfTourists(int numberOfTourists)
        {
            using (var db = new DataContext())
            {
                return db.TourRequests.Where(t => t.Tourists == numberOfTourists).ToList();
            }
        }

        public List<TourRequest> GetAllByCity(string city)
        {
            using (var db = new DataContext())
            {
                return db.TourRequests.Where(t => t.City == city).ToList();
            }
        }

        public List<TourRequestDTO> GetAllByTourist(int touristId)
        {
            using (var db = new DataContext())
            {
                ChangeTourRequestStatus();
                Tourist tourist = db.Tourists.Include(t => t.TourRequests).FirstOrDefault(t => t.Id == touristId);
                List<TourRequest> touristRequests = tourist.TourRequests;

                List<TourRequestDTO> tourRequestDTOs = new List<TourRequestDTO>();

                foreach (TourRequest tourRequest in touristRequests)
                {
                    Guide guide = GetTourRequestGuide(tourRequest);
                    TourRequestDTO tourRequestDTO = GetTourRequestDTO(tourRequest, guide);
                    tourRequestDTOs.Add(tourRequestDTO);
                }

                return tourRequestDTOs;
            }
        }


        public void ChangeTourRequestStatus()
        {
            using (var db = new DataContext())
            {
                DateTime twoDaysAhead;
                List<TourRequest> tourRequests = db.TourRequests.ToList();
                foreach (TourRequest tourRequest in tourRequests)
                {
                    twoDaysAhead = DateTime.Now.AddDays(2);

                    if (tourRequest.StartDate < twoDaysAhead)
                    {
                        tourRequest.RequestStatus = RequestStatus.Invalid;
                    }
                }
                db.SaveChanges();
            }
        }
        public Guide GetTourRequestGuide(TourRequest tourRequest)
        {
            UserRepository userRepository = new UserRepository();
            List<Guide> guides = userRepository.GetAllGuides();
            foreach (Guide guide in guides)
            {
                foreach (TourRequest request in guide.TourRequests)
                {
                    if (request.Id == tourRequest.Id)
                    {
                        return guide;
                    }
                }
            }
            return null;
        }

        public TourRequestDTO GetTourRequestDTO(TourRequest tourRequest, Guide guide)
        {
            return new TourRequestDTO(tourRequest, guide);
        }
        

        public List<TourRequestDTO> GetAllAccepted(int touristId)
        {
            using (var db = new DataContext())
            {
                return GetAllByTourist(touristId).Where(t => t.RequestStatus == RequestStatus.Accepted).ToList();
            }
        }

        public List<TourRequestDTO> GetAllByTouristAndYear(int touristId, int year)
        {
            using (var db = new DataContext())
            {
                return GetAllByTourist(touristId).Where(t => t.StartDate.Year == year || t.EndDate.Year == year).ToList();
            }
        }
        public List<TourRequestDTO> GetAllAcceptedByYear(int touristId, int year)
        {
            using (var db = new DataContext())
            {
                return GetAllByTouristAndYear(touristId, year).Where(t => t.RequestStatus == RequestStatus.Accepted).ToList();
            }
        }
        public double GetAcceptanceRate(int touristId)
        {
            List<TourRequestDTO> tourRequestDTOs = GetAllByTourist(touristId);
            List<TourRequestDTO> acceptedTourRequestDTOs = GetAllAccepted(touristId);
            int tourRequests = tourRequestDTOs.Count;
            int acceptedTourRequests = acceptedTourRequestDTOs.Count;
            if (tourRequests == 0)
            {
                return -1;
            }
            return Math.Round(100 * acceptedTourRequests / (double)tourRequests, 2);
        }

        public double GetYearlyAcceptanceRate(int touristId, int year)
        {
            List<TourRequestDTO> tourRequestDTOs = GetAllByTouristAndYear(touristId, year);
            List<TourRequestDTO> acceptedTourRequestDTOs = GetAllAcceptedByYear(touristId, year);
            int tourRequests = tourRequestDTOs.Count;
            int acceptedTourRequests = acceptedTourRequestDTOs.Count;
            if (tourRequests == 0)
            {
                return -1;
            }
            return Math.Round(100 * acceptedTourRequests / (double)tourRequests, 2);
        }

        public double GetAvgNumOfTourists(int touristId)
        {
            List<TourRequestDTO> tourRequestDTOs = GetAllAccepted(touristId);
            int acceptedTourRequests = tourRequestDTOs.Count;
            int sum = 0;
            foreach (TourRequestDTO tourRequestDto in tourRequestDTOs)
            {
                sum += tourRequestDto.Tourists;
            }
            return Math.Round(sum / (double)acceptedTourRequests, 2);
        }

        public double GetAvgNumOfTouristsByYear(int touristId, int year)
        {
            List<TourRequestDTO> tourRequestDTOs = GetAllAcceptedByYear(touristId, year);
            int acceptedTourRequests = tourRequestDTOs.Count;
            int sum = 0;
            foreach (TourRequestDTO tourRequestDto in tourRequestDTOs)
            {
                sum += tourRequestDto.Tourists;
            }
            return Math.Round(sum / (double)acceptedTourRequests, 2);
        }
        public List<string> GetTourRequestLanguages(int touristId)
        {
            List<string> languages = new List<string>();
            List<TourRequestDTO> tourRequestDTOs = GetAllByTourist(touristId);
            bool isPresent = false;
            foreach (TourRequestDTO tourRequestDTO in tourRequestDTOs)
            {
                isPresent = false;
                foreach (string language in languages)
                {
                    if (language.Equals(tourRequestDTO.Language))
                    {
                        isPresent = true;
                    }
                }
                if (!isPresent)
                {
                    languages.Add(tourRequestDTO.Language);
                }

            }
            return languages;
        }
        public List<string> GetTourRequestLocations(int touristId)
        {
            List<string> locations = new List<string>();
            List<TourRequestDTO> tourRequestDTOs = GetAllByTourist(touristId);
            bool isPresent;
            foreach (TourRequestDTO tourRequestDTO in tourRequestDTOs)
            {
                isPresent = false;
                foreach (string location in locations)
                {
                    if (location.Equals(tourRequestDTO.City))
                    {
                        isPresent = true;
                    }
                }
                if (!isPresent)
                {
                    locations.Add(tourRequestDTO.City);
                }

            }
            return locations;
        }
        public Dictionary<string, double> CountByLanguage(int touristId)
        {
            Dictionary<string, double> tourRequestsByLanguage = new Dictionary<string, double>();
            List<TourRequestDTO> tourRequestDtos = GetAllByTourist(touristId);
            List<string> languages = GetTourRequestLanguages(touristId);
            int countRequestsByLanguage;
            foreach (string language in languages)
            {
                countRequestsByLanguage = 0;
                foreach (TourRequestDTO tourRequestDTO in tourRequestDtos)
                {
                    if (tourRequestDTO.Language.Equals(language))
                    {
                        countRequestsByLanguage++;
                    }
                }
                tourRequestsByLanguage.Add(language, countRequestsByLanguage);
            }
            return tourRequestsByLanguage;
        }

        public Dictionary<string, double> CountByLocation(int touristId)
        {
            Dictionary<string, double> tourRequestsByLocation = new Dictionary<string, double>();
            List<TourRequestDTO> tourRequestDtos = GetAllByTourist(touristId);
            List<string> locations = GetTourRequestLocations(touristId);
            int countRequestsByLocation;
            foreach (string location in locations)
            {
                countRequestsByLocation = 0;    
                foreach (TourRequestDTO tourRequestDTO in tourRequestDtos)
                {
                    if (tourRequestDTO.City.Equals(location))
                    {
                        countRequestsByLocation++;
                    }
                }
                tourRequestsByLocation.Add(location, countRequestsByLocation);
            }
            return tourRequestsByLocation;
        }

        public List<TourDateDTO> GetAcceptedToursByTourist(int touristId)
        {
            TourRepository tourRepository = new TourRepository();
            List<TourRequestDTO> tourRequestDTOs = GetAllAccepted(touristId);
            List<TourDateDTO> acceptedTours = new List<TourDateDTO>();
            
            foreach (TourRequestDTO tourRequestDTO in tourRequestDTOs)
            {
                TourDateDTO tourDateDTO = tourRepository.GetByTourRequest(tourRequestDTO);
                if (tourDateDTO != null)
                {
                    acceptedTours.Add(tourDateDTO);
                }
            }

            return acceptedTours;
        }

        public List<TourRequestDTO> GetAllUnaccepted(int touristId)
        {
            return GetAllByTourist(touristId).Where(t => t.RequestStatus != RequestStatus.Accepted).ToList();
        }

        public bool IsInList(List<Tour> tours, Tour newTour)
        {
            bool isPresent = false;
            foreach(Tour tour in tours)
            {
                if (tour == newTour)
                {
                    isPresent = true;
                }
            }
            return isPresent;
        }
        public List<Tour> GetPartiallyAcceptedTours(int touristId)
        {

            TourRepository tourRepository = new TourRepository();
            TourService tourService = new TourService(tourRepository);
            List<Tour> tours = tourRepository.GetAllTourData();
            List<TourRequestDTO> unacceptedTourRequestDTOs = GetAllUnaccepted(touristId);
            List<Tour> newTours = new List<Tour>();
            foreach (TourRequestDTO tourRequestDTO in unacceptedTourRequestDTOs)
            {
                foreach (Tour tour in tours)
                {
                    Location location = tourService.GetTourLocation(tour.TourId);

                    if ((tourRequestDTO.City.Equals(location.City) && tourRequestDTO.Country.Equals(location.Country)) || tourRequestDTO.Language.Equals(tour.Language))
                    {
                        if (!IsInList(newTours, tour))
                        {
                            newTours.Add(tour);
                        }
                    }
                }
            }
            return newTours;
        }

    }
}

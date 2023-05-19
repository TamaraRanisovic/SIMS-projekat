using InitialProject.DTO;
using InitialProject.Interfaces;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class TourRequestService
    {
        private readonly ITourRequestRepository TourRequestRepository;

        public TourRequestService(ITourRequestRepository tourRequestRepository)
        {
            TourRequestRepository = tourRequestRepository;
        }

        public void Add(TourRequest tourRequest, int touristId, int guideId)
        {
            TourRequestRepository.Add(tourRequest, touristId, guideId);
        }
        public List<TourRequest> GetAll()
        {
            return TourRequestRepository.GetAll();
        }

        public List<TourRequestDTO> GetAllByTourist(int touristId)
        {
            return TourRequestRepository.GetAllByTourist(touristId);
        }

        //TODO
        public bool AcceptRequest(TourRequest tourRequest)
        {

            return false;
        }

        public int Stat(List<TourRequest> requests)
        {

            int num = 0;

            foreach (TourRequest t in requests)
            {
                num++;
            }
            return num;
        }

        public int LocationByYearStat(List<TourRequest> tourRequests, int year)
        {
            int num = 0;

            foreach (TourRequest t in tourRequests)
            {
                if (t.StartDate.Year.Equals(year))
                {
                    num++;
                }
            }
            return num;
        }

        public int RequestsByMonthsInAYearStat(List<TourRequest> tourRequests, int year, int month)
        {
            List<TourRequest> list = FindRequestsByYearAndMonth(tourRequests, year, month);

            return list.Count;
        }

        public List<TourRequest> FindRequestsByYearAndMonth(List<TourRequest> tourRequests, int year, int month)
        {
            List<TourRequest> list = new List<TourRequest>();
            foreach (TourRequest t in tourRequests)
            {
                if (t.StartDate.Year.Equals(year) && t.StartDate.Month.Equals(month))
                {
                    list.Add(t);
                }
            }
            return list;
        }

        public string MostWantedLocation()
        {
            List<TourRequest> requests = new List<TourRequest>();
            List<TourRequest> tourRequests = TourRequestRepository.GetAll();

            PreviousYearRequests(ref requests, tourRequests);

            Dictionary<string, int> locationCounter = new Dictionary<string, int>();

            CountLocation(ref locationCounter, tourRequests);

            return locationCounter.OrderByDescending(x => x.Value).FirstOrDefault().Key;


        }

        public string MostWantedLanguage()
        {
            List<TourRequest> requests = new List<TourRequest>();
            List<TourRequest> tourRequests = TourRequestRepository.GetAll();

            PreviousYearRequests(ref requests, tourRequests);

            Dictionary<string, int> languageCounter = new Dictionary<string, int>();

            CountLanguage(ref languageCounter, tourRequests);

            return languageCounter.OrderByDescending(x => x.Value).FirstOrDefault().Key;


        }

        public void PreviousYearRequests(ref List<TourRequest> requests, List<TourRequest> tourRequests)
        {
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.AddYears(-1);
            foreach (TourRequest t in tourRequests)
            {
                if (t.RequestDate >= dateTime)
                {
                    requests.Add(t);
                }
            }
        }

        public void CountLocation(ref Dictionary<string, int> counter, List<TourRequest> tourRequests)
        {
            foreach (TourRequest t in tourRequests)
            {
                string city = t.City;
                if (counter.ContainsKey(city))
                {
                    counter[city]++;
                }
                else
                {
                    counter[city] = 1;
                }
            }
        }

        public void CountLanguage(ref Dictionary<string, int> counter, List<TourRequest> tourRequests)
        {
            foreach (TourRequest t in tourRequests)
            {
                string language = t.Language;
                if (counter.ContainsKey(language))
                {
                    counter[language]++;
                }
                else
                {
                    counter[language] = 1;
                }
            }
        }
  

        public void ChangeTourRequestStatus()
        {
            TourRequestRepository.ChangeTourRequestStatus();
        }

        public TourRequestDTO GetTourRequestDTO(TourRequest tourRequest, Guide guide)
        {
            return TourRequestRepository.GetTourRequestDTO(tourRequest, guide);

        }

        public List<TourRequestDTO> GetAllAccepted(int touristId)
        {
            return TourRequestRepository.GetAllAccepted(touristId);
        }

        public List<TourRequestDTO> GetAllByTouristAndYear(int touristId, int year)
        {
            return TourRequestRepository.GetAllByTouristAndYear(touristId, year);

        }

        public List<TourRequestDTO> GetAllAcceptedByYear(int touristId, int year)
        {
            return TourRequestRepository.GetAllAcceptedByYear(touristId, year);

        }

     
        public List<TourRequestDTO> GetAllUnaccepted(int touristId)
        {
            return TourRequestRepository.GetAllUnaccepted(touristId);

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

        

        public List<TourDateDTO> GetAcceptedToursByTourist(int touristId)
        {
            TourService tourService = new TourService(new TourRepository());
            List<TourRequestDTO> tourRequestDTOs = GetAllAccepted(touristId);
            List<TourDateDTO> acceptedTours = new List<TourDateDTO>();

            foreach (TourRequestDTO tourRequestDTO in tourRequestDTOs)
            {
                TourDateDTO tourDateDTO = GetByTourRequest(tourRequestDTO);
                if (tourDateDTO != null)
                {
                    acceptedTours.Add(tourDateDTO);
                }
            }

            return acceptedTours;
        }
        public bool IsInList(List<Tour> tours, Tour newTour)
        {
            bool isPresent = false;
            foreach (Tour tour in tours)
            {
                if (tour == newTour)
                {
                    isPresent = true;
                }
            }
            return isPresent;
        }

        public TourDateDTO GetByTourRequest(TourRequestDTO tourRequestDTO)
        {

            LocationRepository locationRepository = new LocationRepository();
            TourService tourService = new TourService(new TourRepository());
            Location location = locationRepository.GetByCityAndCountry(tourRequestDTO.City, tourRequestDTO.Country);

            if (location != null)
            {
                List<Tour> toursByLocation = tourService.GetByLocation(location.LocationId);

                foreach (Tour tour in toursByLocation)
                {
                    if (tourService.GetRequestedTour(tour, tourRequestDTO) != null)
                    {
                        return tourService.GetRequestedTour(tour, tourRequestDTO);
                    }
                }
            }

            return null;
        }

        public bool IsPartiallyAccepted(TourRequestDTO tourRequestDTO, Tour tour)
        {
            TourService tourService = new TourService(new TourRepository());

            Location location = tourService.GetTourLocation(tour.TourId);

            if ((tourRequestDTO.City.Equals(location.City) && tourRequestDTO.Country.Equals(location.Country)) || tourRequestDTO.Language.Equals(tour.Language))
            {
                return true;
            }

            return false;
        }

        public List<Tour> GetPartiallyAcceptedTours(int touristId)
        {

            TourService tourService = new TourService(new TourRepository());
            List<Tour> tours = tourService.GetAllTourData();
            List<TourRequestDTO> unacceptedTourRequestDTOs = GetAllUnaccepted(touristId);
            List<Tour> newTours = new List<Tour>();

            foreach (TourRequestDTO tourRequestDTO in unacceptedTourRequestDTOs)
            {
                foreach (Tour tour in tours)
                {
                    Location location = tourService.GetTourLocation(tour.TourId);

                    if (IsPartiallyAccepted(tourRequestDTO, tour))
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


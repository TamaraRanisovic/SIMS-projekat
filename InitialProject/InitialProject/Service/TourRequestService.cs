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
            TourService tourService = new TourService(new TourRepository());
            List<TourRequestDTO> tourRequestDTOs = GetAllAccepted(touristId);
            List<TourDateDTO> acceptedTours = new List<TourDateDTO>();

            foreach (TourRequestDTO tourRequestDTO in tourRequestDTOs)
            {
                TourDateDTO tourDateDTO = tourService.GetByTourRequest(tourRequestDTO);
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


using InitialProject.DTO;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class TourRequestStatisticsService
    {
        TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
        public TourRequestStatisticsService() { }
        public double GetAcceptanceRate(int touristId)
        {
            List<TourRequestDTO> tourRequestDTOs = tourRequestService.GetAllByTourist(touristId);
            List<TourRequestDTO> acceptedTourRequestDTOs = tourRequestService.GetAllAccepted(touristId);
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
            List<TourRequestDTO> tourRequestDTOs = tourRequestService.GetAllByTouristAndYear(touristId, year);
            List<TourRequestDTO> acceptedTourRequestDTOs = tourRequestService.GetAllAcceptedByYear(touristId, year);
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
            List<TourRequestDTO> tourRequestDTOs = tourRequestService.GetAllAccepted(touristId);
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
            List<TourRequestDTO> tourRequestDTOs = tourRequestService.GetAllAcceptedByYear(touristId, year);
            int acceptedTourRequests = tourRequestDTOs.Count;
            int sum = 0;
            foreach (TourRequestDTO tourRequestDto in tourRequestDTOs)
            {
                sum += tourRequestDto.Tourists;
            }
            return Math.Round(sum / (double)acceptedTourRequests, 2);
        }

        public Dictionary<string, double> CountByLanguage(int touristId)
        {
            Dictionary<string, double> tourRequestsByLanguage = new Dictionary<string, double>();
            List<TourRequestDTO> tourRequestDtos = tourRequestService.GetAllByTourist(touristId);
            List<string> languages = tourRequestService.GetTourRequestLanguages(touristId);
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
            List<TourRequestDTO> tourRequestDtos = tourRequestService.GetAllByTourist(touristId);
            List<string> locations = tourRequestService.GetTourRequestLocations(touristId);
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

    }
}

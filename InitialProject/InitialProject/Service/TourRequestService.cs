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

        public void ChangeTourRequestStatus()
        {
            TourRequestRepository.ChangeTourRequestStatus();
        }

        public Guide GetTourRequestGuide(TourRequest tourRequest)
        {
            return TourRequestRepository.GetTourRequestGuide(tourRequest);
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


        public double GetAcceptanceRate(int touristId)
        {
            return TourRequestRepository.GetAcceptanceRate(touristId);
        }
        public double GetYearlyAcceptanceRate(int touristId, int year)
        {
            return TourRequestRepository.GetYearlyAcceptanceRate(touristId, year);
        }

        public double GetAvgNumOfTourists(int touristId)
        {
            return TourRequestRepository.GetAvgNumOfTourists(touristId);
        }

        public double GetAvgNumOfTouristsByYear(int touristId, int year)
        {
            return TourRequestRepository.GetAvgNumOfTouristsByYear(touristId, year);
        }
        public List<string> GetTourRequestLanguages(int touristId)
        {
            return TourRequestRepository.GetTourRequestLanguages(touristId);

        }
        public List<string> GetTourRequestLocations(int touristId)
        {
            return TourRequestRepository.GetTourRequestLocations(touristId);

        }

        public Dictionary<string, double> CountByLanguage(int touristId)
        {
            return TourRequestRepository.CountByLanguage(touristId);

        }

        public Dictionary<string, double> CountByLocation(int touristId)
        {
            return TourRequestRepository.CountByLocation(touristId);

        }
        public List<TourDateDTO> GetAcceptedToursByTourist(int touristId)
        {
            return TourRequestRepository.GetAcceptedToursByTourist(touristId);

        }
        public List<TourRequestDTO> GetAllUnaccepted(int touristId)
        {
            return TourRequestRepository.GetAllUnaccepted(touristId);

        }
        public List<Tour> GetPartiallyAcceptedTours(int touristId)
        {
            return TourRequestRepository.GetPartiallyAcceptedTours(touristId);

        }


    }
}

using InitialProject.DTO;
using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Interfaces
{
    public interface ITourRequestRepository
    {
        public void Add(TourRequest tourRequest, int touristId, int guideId);
        public List<TourRequest> GetAll();
        public void ChangeTourRequestStatus();
        public Guide GetTourRequestGuide(TourRequest tourRequest);
        public TourRequestDTO GetTourRequestDTO(TourRequest tourRequest, Guide guide);

        public List<TourRequestDTO> GetAllByTourist(int touristId);
        public List<TourRequestDTO> GetAllAccepted(int touristId);
        public List<TourRequestDTO> GetAllByTouristAndYear(int touristId, int year);
        public List<TourRequestDTO> GetAllAcceptedByYear(int touristId, int year);
        public double GetAcceptanceRate(int touristId);

        public double GetYearlyAcceptanceRate(int touristId, int year);
        public double GetAvgNumOfTourists(int touristId);
        public double GetAvgNumOfTouristsByYear(int touristId, int year);
        public List<string> GetTourRequestLanguages(int touristId);
        public List<string> GetTourRequestLocations(int touristId);

        public Dictionary<string, double> CountByLanguage(int touristId);
        public Dictionary<string, double> CountByLocation(int touristId);
        public List<TourDateDTO> GetAcceptedToursByTourist(int touristId);

        public List<TourRequestDTO> GetAllUnaccepted(int touristId);

        public bool IsInList(List<Tour> tours, Tour newTour);
        public List<Tour> GetPartiallyAcceptedTours(int touristId);


    }
}

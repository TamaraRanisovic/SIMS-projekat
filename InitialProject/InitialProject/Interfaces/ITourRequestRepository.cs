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
        public TourRequestDTO GetTourRequestDTO(TourRequest tourRequest, Guide guide);

        public List<TourRequestDTO> GetAllByTourist(int touristId);
        public List<TourRequestDTO> GetAllAccepted(int touristId);
        public List<TourRequestDTO> GetAllByTouristAndYear(int touristId, int year);
        public List<TourRequestDTO> GetAllAcceptedByYear(int touristId, int year);

        public List<TourRequestDTO> GetAllUnaccepted(int touristId);



    }
}

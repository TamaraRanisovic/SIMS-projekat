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
        public List<TourRequestDTO> GetAllByTourist(int touristId);

        public List<TourRequest> GetAllByLocation(Location location);

        public List<TourRequest> GetAllByLanguage(string language);

    }
}

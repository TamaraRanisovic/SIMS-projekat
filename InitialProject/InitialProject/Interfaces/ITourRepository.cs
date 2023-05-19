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
    public interface ITourRepository
    {
        public void Add(Tour tourToAdd);
        public List<Tour> GetAll();
        public List<Tour> GetAllTourData();
        public List<Tour> GetByLocation(int locationId);
        public int GetTouristsNumber(int tourId);
        public void BookTour(int tourId, int touristId, int tourists);
        public Tour GetById(int id);
        public Tour GetByName(string name);
        public void Update(int id, Tour updatedTour);
        public void Delete(int id);
        public List<Tour> GetByStartDate(DateTime startingDate);
        public List<Tour> GetList();
        public List<Tourist> GetTourists(Tour tour);
        public Tour GetByTourReservation(int tourReservationId);
        public TourDateDTO GetByTourRequest(TourRequestDTO tourRequestDTO);
        public Guide GetTourGuide(int tourId);
        public List<Dates> GetTourDates(int tourId);


    }
}

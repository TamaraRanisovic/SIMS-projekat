using InitialProject.DTO;
using InitialProject.Interfaces;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class TourRequestRepository : ITourRequestRepository
    {
        public void Add(TourRequest tourRequest, int touristId, int guideId)
        {

        }

        public List<TourRequest> GetAll()
        {
            using (var db = new DataContext())
            {

                return db.TourRequests.ToList();
            }
        }

        public List<TourRequestDTO> GetAllByTourist(int touristId)
        {
            List<TourRequestDTO> list = new List<TourRequestDTO>();
            return list;
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
                return db.TourRequests.Where(t => t.StartDate.Year == year).ToList();
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

    }
}
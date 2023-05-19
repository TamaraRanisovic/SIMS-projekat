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
                TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
                List<TourRequestDTO> tourRequestDTOs = new List<TourRequestDTO>();

                foreach (TourRequest tourRequest in touristRequests)
                {
                    Guide guide = tourRequestService.GetTourRequestGuide(tourRequest);
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
        
        public List<TourRequestDTO> GetAllUnaccepted(int touristId)
        {
            return GetAllByTourist(touristId).Where(t => t.RequestStatus != RequestStatus.Accepted).ToList();
        }

        
       

    }
}

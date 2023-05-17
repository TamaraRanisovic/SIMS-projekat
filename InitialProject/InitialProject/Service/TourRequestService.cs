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

        public List<TourRequestDTO> GetAllByTourist(int touristId)
        {
            return TourRequestRepository.GetAllByTourist(touristId);
        }

        //TODO
        public bool AcceptRequest()
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

            foreach(TourRequest t in tourRequests)
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

        public List<TourRequest> GetAll()
        {
            return TourRequestRepository.GetAll();
        }
    }
}

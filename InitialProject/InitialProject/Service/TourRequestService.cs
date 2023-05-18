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

        public List<TourRequest> GetAll()
        {
            return TourRequestRepository.GetAll();
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
    }   

}

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
    public class TourRatingService
    {
        private readonly ITourRatingRepository TourRatingRepository;

        public TourRatingService(ITourRatingRepository tourRatingRepository)
        {
            TourRatingRepository = tourRatingRepository;
        }

        public void Add(TourRating tourRating, int touristId, int tourId)
        {
            TourRatingRepository.Add(tourRating, touristId, tourId);
        }

        public List<TourRating> GetAll()
        {
            return TourRatingRepository.GetAll();
        }

        public TourRating GetById(int id)
        {
            return TourRatingRepository.GetById(id);

        }


    }
}

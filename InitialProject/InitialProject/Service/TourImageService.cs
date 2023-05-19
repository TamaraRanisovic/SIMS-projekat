using InitialProject.Interfaces;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class TourImageService
    {
        private readonly ITourImageRepository TourImageRepository;

        public TourImageService(ITourImageRepository tourImageRepository)
        {
            TourImageRepository = tourImageRepository;
        }

        public List<TourImage> GetByTour(int tourId)
        {
            return TourImageRepository.GetByTour(tourId);
        }
    }
}

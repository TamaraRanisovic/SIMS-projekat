using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class TourImagesService
    {
        private readonly TourImagesRepository TourImagesRepository;

        public TourImagesService()
        {
            
        }
<<<<<<< Updated upstream
        public TourImagesService(TourImagesRepository tourImagesRepository)
        {
            TourImagesRepository = tourImagesRepository;
        }
        public List<TourImages> GetTourImages(int tourId)
        {
            TourImagesRepository tourImagesRepository = new TourImagesRepository();
            return tourImagesRepository.GetTourImages(tourId);
=======

        public List<TourImages> GetAllByTour(int tourId)
        {
            return tourImagesRepository.GetAllByTour(tourId);
>>>>>>> Stashed changes
        }
    }
}

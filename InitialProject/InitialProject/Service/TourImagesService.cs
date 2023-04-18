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
        TourImagesRepository tourImagesRepository = new TourImagesRepository();

        public TourImagesService()
        {
            
        }

        public List<TourImages> GetTourImages(int tourId)
        {
            return tourImagesRepository.GetTourImages(tourId);
        }
    }
}

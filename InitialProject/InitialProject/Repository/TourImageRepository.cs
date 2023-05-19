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
    public class TourImageRepository : ITourImageRepository
    {

        public TourImageRepository() { }

        public TourImage GetById(int id)
        {
            using (var db = new DataContext())
            {
                return db.TourImages.FirstOrDefault(x => x.Id == id);
            }
        }
       
        public List<TourImage> GetByTour(int tourId)
        { 
            List<TourImage> images = new List<TourImage>();
            using (var db = new DataContext())
            {
                var tour = db.Tours.Include(t => t.Images).SingleOrDefault(t => t.TourId == tourId);
                if (tour != null)
                {
                    images.AddRange(tour.Images);
                }
            }
            return images;
        }
        
    }
}


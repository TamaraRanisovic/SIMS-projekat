using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Interfaces
{
    public interface ITourRatingRepository
    {
        public void Add(TourRating tourRating, int touristId, int tourId);
        public List<TourRating> GetAll();
        public TourRating GetById(int id);

    }
}

using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Interfaces
{
    public interface ITourImageRepository
    {
        public TourImage GetById(int id);

        public List<TourImage> GetByTour(int tourId);

    }
}

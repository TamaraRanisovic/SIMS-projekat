using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class TouristsRepository
    {
        public TouristsRepository() { } 

        public List<Tourist> GetTourists(int tourId)
        { 
            List<Tourist> tourists = new List<Tourist>();
            using (var db = new DataContext())
            {
                var tour = db.Tours.Include(t => t.Tourists).SingleOrDefault(t => t.TourId == tourId);
                if (tour != null)
                {
                    tourists.AddRange(tour.Tourists);
                }
            }
            return tourists;
        }
    }
}

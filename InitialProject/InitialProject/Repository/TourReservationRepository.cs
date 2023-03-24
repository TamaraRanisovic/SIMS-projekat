using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class TourReservationRepository
    {
        public TourReservationRepository()
        {

        }
        public List<TourReservation> GetAllTourReservations()
        {
            using (var db = new DataContext())
            {
                return db.TourReservations.ToList();
            }
        }
    }
}

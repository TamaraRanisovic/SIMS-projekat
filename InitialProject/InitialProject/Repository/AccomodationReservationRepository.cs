using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class AccomodationReservationRepository
    {
        public AccomodationReservationRepository() { }


        public List<AccomodationReservation> GetAllExpiredBy(int day, int month, int year)
        {
            List<AccomodationReservation> expiredReservations = new List<AccomodationReservation>();

            using(var db = new DataContext())
            {
                expiredReservations = db.AccomodationReservations.Include(ar => ar.Accomodations) 
                                                                 .Include(ar => ar.Users)
                                        .Where(ar => ((ar.CheckOutDate.Day >= (day - 5)) && (ar.CheckOutDate.Day <= day)) 
                                                   && (ar.CheckOutDate.Month == month) 
                                                   && (ar.CheckOutDate.Year == year)
                                              ).ToList();
            } 
            return expiredReservations;
        }
    }
}

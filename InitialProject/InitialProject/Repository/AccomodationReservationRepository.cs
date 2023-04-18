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
                                                                 .Include(ar => ar.User)
                                        .Where(ar => ((ar.CheckOutDate.Day >= (day - 5)) && (ar.CheckOutDate.Day <= day)) 
                                                   && (ar.CheckOutDate.Month == month) 
                                                   && (ar.CheckOutDate.Year == year)
                                              ).ToList();
            } 
            return expiredReservations;
        }

        public List<AccomodationReservation> GetAllBetween(DateTime startingDate, DateTime endingDate)
        {

            List<AccomodationReservation> accommodationReservations = new List<AccomodationReservation>();

            using (var dbContext = new DataContext())
            {
                accommodationReservations = dbContext.AccomodationReservations
                                            .Where(ar => ((startingDate >= ar.CheckInDate && startingDate <= ar.CheckOutDate) || (endingDate >= ar.CheckInDate && endingDate <= ar.CheckOutDate)) ||
                                                         (ar.CheckInDate >= startingDate && ar.CheckInDate <= endingDate) || (ar.CheckOutDate >= startingDate && (ar.CheckOutDate <= endingDate))
                                                   )
                                           .Include(r => r.Accomodations)    
                                           .Include(r => r.User)
                                           .ToList();
            }
            return accommodationReservations;
        }

        public void UpdateScheduledDatesBy(int id, DateTime newBegginingDate, DateTime newEndingDate)
        {

            AccomodationReservation accommodationReservation = new();

            var db = new DataContext();
            accommodationReservation = db.AccomodationReservations.Find(id);

            accommodationReservation.CheckInDate = newBegginingDate;
            accommodationReservation.CheckOutDate = newEndingDate;
            db.SaveChanges();
        }

    }
}

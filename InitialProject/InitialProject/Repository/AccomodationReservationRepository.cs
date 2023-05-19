using InitialProject.Model;
using InitialProject.Resources.Images;
using Microsoft.EntityFrameworkCore;
using InitialProject.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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

        public List<int> GetReservationYearsBy(Accomodation accommodation)
        {
            List<int> reservationYears = new List<int>();

            using (var dbContext = new DataContext())
            {
                reservationYears = dbContext.AccommodationReservations
                                           .Select(r => r.CheckInDate.Year).Distinct().ToList();
            }

            return reservationYears;
        }

         public int GetCountBy(int year, Accomodation accommodation)
         {

             List<AccommodationReservation> annualReservations = new List<AccommodationReservation>();

             using (var dbContext = new DataContext())
             {
                 annualReservations = dbContext.AccommodationReservations
                                            .Where(r => r.CheckInDate.Year == year).ToList();

             }

             int count = 0;
             foreach (var reservation in annualReservations)
             {



                 if (reservation.AccId == accommodation.Id)
                 {

                     count++;
                 }


             }
             return count;

         }



        public int GetCancellationCountBy(int year, Accomodation accommodation)
        {

            List<AccommodationReservation> annualCanceledReservations = new List<AccommodationReservation>();

            using (var dbContext = new DataContext())
            {
                annualCanceledReservations = dbContext.AccommodationReservations
                                            .Where(r => r.CheckInDate.Year == year)
                                            .Where(r => r.Cancelled == true)
                                            .ToList();
            }

            int count = 0;
            foreach (var reservation in annualCanceledReservations)
            {



                if (reservation.AccId == accommodation.Id)
                {

                    count++;
                }


            }
            return count;
        }

        public double GetOccupancyBy(int year, Accomodation accommodation)
        {

            List<AccommodationReservation> annualReservations = new List<AccommodationReservation>();

            using (var dbContext = new DataContext())
            {
                annualReservations = dbContext.AccommodationReservations
                                           .Where(r => r.CheckInDate.Year == year)
                                           .ToList();
            }

            TimeSpan duration = new TimeSpan(0, 0, 0, 0);

            foreach (var reservation in annualReservations)
            {

                if (reservation.AccId == accommodation.Id)
                {


                    duration += (reservation.CheckOutDate - reservation.CheckInDate);
                }
            }
            return Math.Round(Convert.ToDouble(duration.Days) / 366 * 100, 2);
        }

        public int GetCountBy(int year, int month, Accomodation accommodation)
        {

            List<AccommodationReservation> monthlyReservations = new List<AccommodationReservation>();

            using (var dbContext = new DataContext())
            {
                monthlyReservations = dbContext.AccommodationReservations
                                           .Where(r => r.CheckInDate.Year == year && r.CheckInDate.Month == month)
                                           .ToList();
            }

            int count = 0;
            foreach (var reservation in monthlyReservations)
            {



                if (reservation.AccId == accommodation.Id)
                {

                    count++;
                }


            }
            return count;
        }

        public int GetCancellationCountBy(int year, int month, Accomodation accommodation)
        {

            List<AccommodationReservation> canceledReservations = new List<AccommodationReservation>();

            using (var dbContext = new DataContext())
            {
                canceledReservations = dbContext.AccommodationReservations
                                            .Where(r => r.CheckInDate.Year == year && r.CheckInDate.Month == month)
                                            .Where(r => r.Cancelled == true)
                                            .ToList();
            }

            int count = 0;
            foreach (var reservation in canceledReservations)
            {



                if (reservation.AccId == accommodation.Id)
                {

                    count++;
                }


            }
            return count;
        }

            public double GetOccupancyBy(int year, int month, Accomodation accommodation)
        {

            List<AccommodationReservation> monthlyReservations = new List<AccommodationReservation>();

            using (var dbContext = new DataContext())
            {
                monthlyReservations = dbContext.AccommodationReservations
                                           .Where(r => r.CheckInDate.Year == year && r.CheckInDate.Month == month)
                                           .ToList();
            }

            TimeSpan duration = new TimeSpan(0, 0, 0, 0);

            foreach (var reservation in monthlyReservations)
            {

                duration += (reservation.CheckOutDate - reservation.CheckInDate);

            }

            return Math.Round(Convert.ToDouble(duration.Days) / 366 * 100, 2);
        }
         public List<AccomodationReservation> GetAllAccomodationReservation()
        {
            using(var db = new DataContext())
            {
                return db.AccomodationReservations.ToList();
            }
        }

        public AccomodationReservation GetAccomodationReservationById(int accId)
        {
            using (var db = new DataContext())
            {
                List<AccomodationReservation> allAccomodationReservation = GetAllAccomodationReservation();
                foreach (AccomodationReservation accomodationReservation in allAccomodationReservation)
                {
                    if (accomodationReservation.Id == accId)
                    if (accomodationReservation.AccomodationId == accId)
                    {
                        return accomodationReservation;
                    }
                }
            }
            return null;
        }

        //   public bool IsAvailable(DateTime start,DateTime end)
        //  {
        //     foreach(var r in Accomodation.)
        // }


        public void BookAcc(int accId,int guestId,int guestsNumber, DateTime start,DateTime end)
        {
            AccomodationReservation accomodationReservation = new AccomodationReservation();
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            AccomodationService accomodationService = new AccomodationService();

            using(var db = new DataContext())
            {
                Guest guest = db.Guests.Find(guestId);
                Accomodation accomodation = db.Accomodations.Find(accId);
                if(guest != null && accomodation != null)
                {
                    guest.AccomodationReservations.Add(accomodationReservation);
                    accomodation.AccomodationReservations.Add(accomodationReservation);
                    accomodation.Guests.Add(guest);
                    db.SaveChanges();
                }
            }
            Console.WriteLine("Succesfully reserved accomodation");
        } 


    }
}

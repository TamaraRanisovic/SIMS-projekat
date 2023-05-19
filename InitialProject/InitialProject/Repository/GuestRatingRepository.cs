using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class GuestRatingRepository
    {
        public GuestRatingRepository() { }

        public void Save(GuestRating guestRating)
        {
            using var db = new DataContext();

            db.Add(guestRating);
            db.SaveChanges();
        }

        public List<AccomodationReservation> GetGradedReservations()
        {
            List<AccomodationReservation> reservation = new List<AccomodationReservation>();

            using (var db = new DataContext())
            {
                reservation = (List<AccomodationReservation>)db.GuestRatings.Select(t => t.AccomodationReservation);
            }
            return reservation;
        }

        public List<GuestRating> GetAllGuestRatings()
        {
            using (var db = new DataContext())
            {
                return db.GuestRatings.Include(t => t.AccomodationReservation)
                    .ToList();
            }
        }


        public GuestRating GetRatingByOwnerId(int ownerId)
        {
            using (var db = new DataContext())
            {
                List<GuestRating> allGuestRatings = GetAllGuestRatings();
                foreach (GuestRating guestRating in allGuestRatings)
                {
                    if (guestRating.IdOwner == ownerId)
                    {
                        return guestRating;
                    }
                }
            }
            return null;
        }

    }
}

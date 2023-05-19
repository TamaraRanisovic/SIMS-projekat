using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class RenovationRepository
    {

        private void UpdateLastAccommodationRenovation(Renovation renovation)
        {

            List<Accomodation> accommodations = new();

            using (DataContext db = new())
            {
                accommodations = db.Accomodations.Where(t => t.Id.Equals(renovation.Accomodation.Id))
                    .ToList();

                accommodations.ForEach(t => t.LastRenovation = renovation.End);
                db.SaveChanges();
            }
        }
        public void Save(Renovation renovation)
        {

           UpdateLastAccommodationRenovation(renovation);

            using (DataContext db = new())
            {
                db.ChangeTracker.TrackGraph(renovation, node =>
                node.Entry.State = !node.Entry.IsKeySet ? EntityState.Added : EntityState.Unchanged);

                db.SaveChanges();
            }

        }

        public List<Renovation> GetAll()
        {
            List<Renovation> renovations = new();

            using (DataContext db = new())
            {
                renovations = db.Renovations
                                .Include(t => t.Accomodation)
                                .ToList();
            }
            return renovations;
        }

        private Accomodation GetAccommodationBy(Renovation existingRenovation)
        {

            Renovation renovation = new Renovation();

            using (DataContext db = new())
            {
                renovation = db.Renovations
                                   .Where(t => t.Id.Equals(existingRenovation.Id))
                                   .Include(t => t.Accomodation)
                                   .First();
            }


            return renovation.Accomodation;
        }

        public void Delete(Renovation erasureRenovation)
        {
            using (DataContext db = new())
            {
                Accomodation accommodationRenovation = GetAccommodationBy(erasureRenovation);

                db.Remove(erasureRenovation);

                db.SaveChanges();

                UpdateLastAccommodationRenovation(GetLastRenovationBy(accommodationRenovation));

                db.SaveChanges();
            }
        }

        private Renovation GetLastRenovationBy(Accomodation accommodation)
        {

            Renovation renovation = new Renovation();

            using (DataContext db = new())
            {
                renovation = db.Renovations
                                   .Include(t => t.Accomodation)
                                   .Where(t => t.Accomodation.Id.Equals(accommodation.Id))
                                   .OrderBy(t => t.End).Last();
            }

            return renovation;
        }

    }
}

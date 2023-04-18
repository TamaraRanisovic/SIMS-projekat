using InitialProject.Model;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class AccomodationRepository
    {

        public AccomodationRepository() { }

        public List<Accomodation> GetAllAccomodations()
        {
            using (var db = new DataContext())
            {
                return db.Accomodations.ToList();
            }
        }

        public Accomodation GetAccomodationById(int accId)
        {
            using(var db = new DataContext())
            {
                List<Accomodation> allAccomodations = GetAllAccomodations();
                foreach(Accomodation accomodation in allAccomodations)
                {
                    if(accomodation.AccId == accId)
                    {
                        return accomodation;
                    }
                }
            }
            return null;
        }

        public List<Accomodation> GetAccomodationsByLocation(int locationId)
        {
            List<Accomodation> accomodationsByLocation = new List<Accomodation>();
            using (var db = new DataContext())
            {
                var location = db.Locations.Include(a => a.Accomodations).SingleOrDefault(a => a.LocationId == locationId);
                if (location != null)
                {
                    accomodationsByLocation.AddRange(location.Accomodations);
                }
            }
            return accomodationsByLocation;
        }

        public int GetNumberOfGuestsInAccomodation(int accId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            using(var db = new DataContext())
            {
                var acc = db.Accomodations.Include(a => a.AccomodationReservations).SingleOrDefault(a => a.AccId == accId);

                int numberOfGuestsInAccomodation = 0;
                List<AccomodationReservation> accomodationReservations = acc.AccomodationReservations.ToList();
                foreach(AccomodationReservation accomodationReservation in accomodationReservations)
                {
                    numberOfGuestsInAccomodation += accomodationReservation.NumberOfGuests;

                }
                return numberOfGuestsInAccomodation;
            }
        }

    }
}
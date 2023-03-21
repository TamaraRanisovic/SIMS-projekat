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


    }
}
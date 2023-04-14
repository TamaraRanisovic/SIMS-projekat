using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class LocationRepository
    {
        public LocationRepository()
        {
            
        }

        public List<Location> GetAllLocations()
        {
            using (var db = new DataContext())
            {
                return db.Locations.ToList();
            }
        }

        

        public Location GetByCityAndCountry(string city, string country)
        {
            using (var db = new DataContext())
            {
                List<Location> allLocations = GetAllLocations();
                foreach (Location location in allLocations)
                {
                    if (location.City.Equals(city) && location.Country.Equals(country))
                    {
                        return location;
                    }
                }
            }
            return null;
        }


    }
}

using InitialProject.Interfaces;
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
    public class LocationRepository : ILocationRepository
    {
        public LocationRepository() { }
        public void Add(Location locationToAdd)
        {
            using (var db = new DataContext())
            {
                db.Locations.Add(locationToAdd);
                db.SaveChanges();
            }

        }

        public List<Location> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Locations.ToList();
            }
        }

        public void Delete(int id)
        {
            using (var db = new DataContext())
            {
                var locationToDelete = db.Locations.FirstOrDefault(t => t.LocationId == id);

                if (locationToDelete != null)
                {
                    db.Locations.Remove(locationToDelete);
                    db.SaveChanges();
                }
            }
        }

        public void Update(int id, Location locationToUpdate)
        {
            using (var db = new DataContext())
            {
                var location = db.Locations.FirstOrDefault(t => t.LocationId == id);

                if (location != null)
                {
                    location.City = locationToUpdate.City;
                    location.Country = locationToUpdate.Country;
                    location.Tours = locationToUpdate.Tours;
                    location.Accomodations = locationToUpdate.Accomodations;
                    db.SaveChanges();
                }
            }
        }

        public Location GetById(int id)
        {
            using (var db = new DataContext())
            {
                return db.Locations.FirstOrDefault(t => t.LocationId == id);
            }
        }

        public Location GetByCityAndCountry(string city, string country)
        {
            using (var db = new DataContext())
            {
                List<Location> allLocations = GetAll();
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
using InitialProject.DTO;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class TourRepository
    {
        public TourRepository()
        {

        }

        public List<Tour> GetAllTours() 
        {
            using (var db = new DataContext())
            {
                //if (db.Tours.ToList().Count == 0) { }
                return db.Tours.ToList();
            }
        }

        public List<Tour> GetToursByLocation(int locationId)
        {
            List<Tour> toursByLocation = new List<Tour>();
            using (var db = new DataContext())
            {
                var location = db.Locations.Include(t => t.Tours).SingleOrDefault(t => t.LocationId == locationId);
                if (location != null)
                {
                    toursByLocation.AddRange(location.Tours);
                }
            }
            return toursByLocation;
        }

        


        /*
        public static List<Tour> GetByLocation(string city, string country)  // DTO??? I DA LI JE DOBRO?
        {
            // List<Tour> toursByLocation = new List<Tour>();
            using (var db = new DataContext())
            {
                foreach (Location location in db.Locations)
                {
                    if (location.City.Equals(city) && location.Country.Equals(country))
                    {
                        return location.Tours;
                        // toursByLocation.AddRange(location.Tours);
                    }
                }
            }
            return null;
        }*/

        // GetByLocation preko LocationDTO
        /*public static List<Tour> GetByLocation(LocationDTO locationDTO)  // DTO??? I DA LI JE DOBRO?
        {
            //List<Tour> toursByLocation = new List<Tour>();
            using (var db = new DataContext())
            {
                foreach (Location location in db.Locations)
                {
                    if (location.City.Equals(locationDTO.City) && location.Country.Equals(locationDTO.Country))
                    {
                        return location.Tours;
                    }
                }
            }
            return null;
        }
        
        public static List<Tour> GetByDuration(int duration)
        {
            List<Tour> toursByDuration = new List<Tour>();
            using (var db = new DataContext())
            {
                foreach (Tour tour in db.Tours)
                {
                    if (tour.Duration == duration)
                    {
                        toursByDuration.Add(tour);
                    }
                }
            }
            return toursByDuration;
        }

        public static List<Tour> GetByLanguage(string language)
        {
            List<Tour> toursByLanguage = new List<Tour>();
            using (var db = new DataContext())
            {
                foreach (Tour tour in db.Tours)
                {
                    if (tour.Language.Equals(language))
                    {
                        toursByLanguage.Add(tour);
                    }
                }
            }
            return toursByLanguage;
        }

        // 
        public static List<Tour> GetByGuestsNumber(int guestsNumber)  //IME SREDITI FUNKCIJE
        {
            List<Tour> toursByNumber = new List<Tour>();
            using (var db = new DataContext())
            {
                foreach (Tour tour in db.Tours)
                {
                    if (tour.MaxGuests - tour.Tourists.Count >= guestsNumber)
                    {
                        toursByNumber.Add(tour);
                    }
                }
            }
            return toursByNumber;

        }*/
    }
}

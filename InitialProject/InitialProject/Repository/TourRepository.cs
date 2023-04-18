using InitialProject.DTO;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class TourRepository
    {

        public TourRepository() { }

        public void AddTour(Tour tourToAdd)
        {
            using (var db = new DataContext())
            {
                db.Tours.Add(tourToAdd);
                db.SaveChanges();
            }
        }

        public List<Tour> GetAllTours()
        {
            using (var db = new DataContext())
            {
                return db.Tours.ToList();
            }
        }


        public Tour GetTourById(int id)
        {
            using (var db = new DataContext())
            {
                return db.Tours.FirstOrDefault(t => t.TourId == id);
            }
        }

        public Tour GetTourByName(string name)
        {
            using (var db = new DataContext())
            {
                return db.Tours.FirstOrDefault(t => t.Name == name);
            }
        }

        public void UpdateTour(int id, Tour updatedTour)
        {
            using (var context = new DataContext())
            {
                var tourToUpdate = context.Tours.FirstOrDefault(t => t.TourId == id);
                if (tourToUpdate != null)
                {
                    tourToUpdate.Name = updatedTour.Name;
                    tourToUpdate.Description = updatedTour.Description;
                    tourToUpdate.Language = updatedTour.Language;
                    tourToUpdate.MaxGuests = updatedTour.MaxGuests;
                    tourToUpdate.StartTime = updatedTour.StartTime;
                    tourToUpdate.EndTime = updatedTour.EndTime;
                    tourToUpdate.Duration = updatedTour.Duration;
                    tourToUpdate.Checkpoints = updatedTour.Checkpoints;
                    tourToUpdate.Images = updatedTour.Images;
                    tourToUpdate.Tourists = updatedTour.Tourists;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTour(int id)
        {
            using (var db = new DataContext())
            {
                var tourToDelete = db.Tours.FirstOrDefault(t => t.TourId == id);

                if (tourToDelete != null)
                {
                    db.Tours.Remove(tourToDelete);
                    db.SaveChanges();
                }
            }
        }

        public List<Tour> GetToursByStartDate(DateTime startTime)
        {
            List<Tour> todaysTour = new List<Tour>();
            using (var db = new DataContext())
            {
                todaysTour = db.Tours.Where(t => t.StartTime == startTime).Include(t => t.Checkpoints).Include(t=>t.Tourists).Include(t => t.Images).ToList();

            }
            return todaysTour;
        }

        public List<Tour> GetToursList()
        {
            List<Tour> toursWithCheckpoints = new List<Tour>();
            using (var db = new DataContext())
            {
               toursWithCheckpoints = db.Tours.Include(t => t.Checkpoints).Include(t => t.Tourists).Include(t => t.Images).ToList();
            }
            return toursWithCheckpoints; 
        }

        public List<Tourist> GetTourists(Tour tour)
        {
            using (var db = new DataContext())
            {
                {
                  
                    var tourToReturn = db.Tours.Include(t => t.Tourists).FirstOrDefault(t => t.TourId == tour.TourId);

                    
                    if (tour == null)
                    {
                        return new List<Tourist>();
                    }

                    
                    return tour.Tourists;
                }
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

        public int GetNumberOfTouristsInATour(int tourId)
        {
            TourReservationRepository tourReservationRepository = new TourReservationRepository();
            using (var db = new DataContext())
            {
                var tour = db.Tours.Include(t => t.TourReservations).SingleOrDefault(t => t.TourId == tourId);
                
                int numberOfTouristsInATour = 0;
                List<TourReservation> tourReservations = tour.TourReservations.ToList();
                foreach (TourReservation tourReservation in tourReservations)
                {
                    numberOfTouristsInATour += tourReservation.TouristsNumber;
                }
                return numberOfTouristsInATour;
            }
        }

        public void BookATour(int tourId, int touristId, int touristsNumber)
        {
            TourReservation tourReservation = new TourReservation(touristsNumber);
            using (var db = new DataContext())
            {
                Tourist tourist = db.Tourists.Find(touristId);
                Tour tour = db.Tours.Find(tourId);
                if (tourist != null && tour != null)
                {
                    tourist.TourReservations.Add(tourReservation);
                    tour.TourReservations.Add(tourReservation);
                    tour.Tourists.Add(tourist);
                    db.SaveChanges();
                }
                
            }
            Console.WriteLine("Uspesno ste rezervisali turu.");

        }

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

        }



        public void UpdateTour(int id, Tour updatedTour)
        {
            using (var context = new DataContext())
            {
                var tourToUpdate = context.Tours.FirstOrDefault(t => t.TourId == id);
                if (tourToUpdate != null)
                {
                    tourToUpdate.Name = updatedTour.Name;
                    tourToUpdate.Description = updatedTour.Description;
                    tourToUpdate.Language = updatedTour.Language;
                    tourToUpdate.MaxGuests = updatedTour.MaxGuests;
                    tourToUpdate.StartTime = updatedTour.StartTime;
                    tourToUpdate.EndTime = updatedTour.EndTime;
                    tourToUpdate.Duration = updatedTour.Duration;
                    tourToUpdate.Checkpoints = updatedTour.Checkpoints;
                    tourToUpdate.Images = updatedTour.Images;
                    tourToUpdate.Tourists = updatedTour.Tourists;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteTour(int id)
        {
            using (var db = new DataContext())
            {
                var tourToDelete = db.Tours.FirstOrDefault(t => t.TourId == id);

                if (tourToDelete != null)
                {
                    db.Tours.Remove(tourToDelete);
                    db.SaveChanges();
                }
            }
        }

        public List<Tour> GetToursByStartDate(DateTime startTime)
        {
            List<Tour> todaysTour = new List<Tour>();
            using (var db = new DataContext())
            {
                todaysTour = db.Tours.Where(t => t.StartTime == startTime).Include(t => t.Checkpoints).Include(t=>t.Tourists).Include(t => t.Images).ToList();

            }
            return todaysTour;
        }

        public List<Tour> GetToursList()
        {
            List<Tour> toursWithCheckpoints = new List<Tour>();
            using (var db = new DataContext())
            {
               toursWithCheckpoints = db.Tours.Include(t => t.Checkpoints).Include(t => t.Tourists).Include(t => t.Images).ToList();
            }
            return toursWithCheckpoints; 
        }

        public List<Tourist> GetTourists(Tour tour)
        {
            using (var db = new DataContext())
            {
                {
                  
                    var tourToReturn = db.Tours.Include(t => t.Tourists).FirstOrDefault(t => t.TourId == tour.TourId);

                    
                    if (tour == null)
                    {
                        return new List<Tourist>();
                    }

                    
                    return tour.Tourists;
                }
            }
        }
    }
}

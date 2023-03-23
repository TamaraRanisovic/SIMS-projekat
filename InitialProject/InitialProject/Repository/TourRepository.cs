﻿using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}

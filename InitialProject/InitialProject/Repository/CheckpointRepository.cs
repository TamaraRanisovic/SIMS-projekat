﻿using InitialProject.Interfaces;
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
    public class CheckpointRepository : ICheckpointRepository
    {
        public CheckpointRepository() { }

        public List<Checkpoint> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.Checkpoints.Include(t=>t.Tourists).ThenInclude(c=>c.TourRatings).Include(t=>t.TourReservations).ToList();
            }
        }

        public Checkpoint GetById(int id)
        {
            using (var db = new DataContext())
            {
                return db.Checkpoints.Where(t=>t.CheckpointId == id).Include(t => t.Tourists).ThenInclude(c => c.TourRatings).Include(t => t.TourReservations).FirstOrDefault();
            }
        }

        public List<Checkpoint> GetByTour(int tourId)
        {
            List<Checkpoint> checkpoints = new List<Checkpoint>();
            using (var db = new DataContext())
            {
                var tour = db.Tours.Include(t => t.Checkpoints).SingleOrDefault(t => t.TourId == tourId);
                if (tour != null)
                {
                    checkpoints.AddRange(tour.Checkpoints);
                }
            }
            return checkpoints;
        }
    }
}

﻿using InitialProject.Model;
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
        public AccomodationRepository()
        {

        }

        public void AddAccomodation(Accomodation accomodation)
        {
            using (var db = new DataContext())
            {
                db.Accomodations.Add(accomodation);
                db.SaveChanges();
            }
        }

        public static List<Accomodation> GetAllAccomodations()
        {
            using (var db = new DataContext())
            {
                return db.Accomodations.ToList();
            }
        }

        public Accomodation GetAccomodationById(int accId)
        {
            using (var db = new DataContext())
            {
                foreach (Accomodation accomodation in db.Accomodations)
                {
                    if (accomodation.Id == accId)
                    {
                        return accomodation;
                    }
                }
            }
            return null;
        }

        public void UpdateAccomodation(Accomodation updatedAccomodation)
        {
            using (var db = new DataContext())
            {
                var accomodation = db.Accomodations.FirstOrDefault(t => t.Id == updatedAccomodation.Id);
                if (accomodation != null)
                {
                    accomodation.Name = updatedAccomodation.Name;
                    accomodation.AccomodationType = updatedAccomodation.AccomodationType;
                    accomodation.MaxGuests = updatedAccomodation.MaxGuests;
                    accomodation.MinReservationDays = updatedAccomodation.MinReservationDays;
                    accomodation.DaysBeforeCanceling = updatedAccomodation.DaysBeforeCanceling;
                    accomodation.Images = updatedAccomodation.Images;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteAccomodation(int AccId)
        {
            using (var db = new DataContext())
            {
                var accomodation = db.Accomodations.FirstOrDefault(t => t.Id == AccId);
                if (accomodation != null)
                {
                    db.Accomodations.Remove(accomodation);
                    db.SaveChanges();
                }
            }
        }


        public void UpdateClassBy(string accommodationClass)
        {
            List<Accomodation> Accommodations = new();

            using (DataContext db = new())
            {
                Accommodations = db.Accomodations
                    .ToList();

                Accommodations.ForEach(t => t.Class = accommodationClass);
                db.SaveChanges();
            }
        }

    }
}

using InitialProject.Model;
using InitialProject.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InitialProject.Repository
{
    public class AccomodationReservationRepository
    {
        public AccomodationReservationRepository() { }

        public List<AccomodationReservation> GetAllAccomodationReservation()
        {
            using(var db = new DataContext())
            {
                return db.AccomodationReservations.ToList();
            }
        }

        public AccomodationReservation GetAccomodationReservationById(int accId)
        {
            using (var db = new DataContext())
            {
                List<AccomodationReservation> allAccomodationReservation = GetAllAccomodationReservation();
                foreach (AccomodationReservation accomodationReservation in allAccomodationReservation)
                {
                    if (accomodationReservation.Id == accId)
                    {
                        return accomodationReservation;
                    }
                }
            }
            return null;
        }


        public void BookAcc(int accId,int guestId,int guestsNumber, DateTime start,DateTime end)
        {
            AccomodationReservation accomodationReservation = new AccomodationReservation();
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            AccomodationService accomodationService = new AccomodationService();

            using(var db = new DataContext())
            {
                Guest guest = db.Guests.Find(guestId);
                Accomodation accomodation = db.Accomodations.Find(accId);
                if(guest != null && accomodation != null)
                {
                    guest.AccomodationReservations.Add(accomodationReservation);
                    accomodation.AccomodationReservations.Add(accomodationReservation);
                    accomodation.Guests.Add(guest);
                    db.SaveChanges();
                }
            }
            Console.WriteLine("Succesfully reserved accomodation");
        } 

    }
}

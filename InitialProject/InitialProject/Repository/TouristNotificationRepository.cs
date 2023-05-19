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
    public class TouristNotificationRepository : ITouristNotificationsRepository
    {
        public TouristNotificationRepository()
        {
            
        }

        public void AddNewTourNotification(int tourId)
        {
            using (var db = new DataContext())
            {
                TouristNotification newTourNotification = new TouristNotification();
                newTourNotification.Type = TouristNotificationType.NewTour;
                db.TouristNotifications.Add(newTourNotification);
            }
                

        }

        public void Delete(TouristNotification touristNotifications)
        {
            using (var db = new DataContext())
            {
                db.TouristNotifications.Remove(touristNotifications);
                db.SaveChanges();
            }
        }
        public List<TouristNotification> GetAll()
        {
            using (var db = new DataContext())
            {
                return db.TouristNotifications.ToList();
            }
        }

        public List<TouristNotification> GetByTourist(int touristId)
        {
            using (var db = new DataContext())
            {
                var touristToReturn = db.Tourists.Include(t => t.TouristNotifications).FirstOrDefault(t => t.Id == touristId);

                List<TouristNotification> touristNotifications = new List<TouristNotification>();
                touristNotifications.AddRange(touristToReturn.TouristNotifications);
                return touristNotifications;
            }
        }
    }
}

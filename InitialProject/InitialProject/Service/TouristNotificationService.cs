using InitialProject.Interfaces;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class TouristNotificationsService
    {
        private readonly ITouristNotificationsRepository TouristNotificationsRepository;
        public TouristNotificationsService(ITouristNotificationsRepository touristNotificationsRepository)
        {
            TouristNotificationsRepository = touristNotificationsRepository;
        }

        public void Delete(TouristNotification touristNotifications)
        {
            TouristNotificationsRepository.Delete(touristNotifications);
        }

        public List<TouristNotification> GetAll()
        {
            return TouristNotificationsRepository.GetAll();
        }
        public List<TouristNotification> GetByTourist(int touristId)
        {
            return TouristNotificationsRepository.GetByTourist(touristId);
        }

    }
}

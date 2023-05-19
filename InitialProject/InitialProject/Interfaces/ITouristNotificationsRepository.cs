using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Interfaces
{
    public interface ITouristNotificationsRepository
    {
        public void Delete(TouristNotification touristNotifications);
        public List<TouristNotification> GetAll();
        public List<TouristNotification> GetByTourist(int touristId);

    }
}

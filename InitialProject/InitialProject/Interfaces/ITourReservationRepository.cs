using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Interfaces
{
    public interface ITourReservationRepository
    {
        public List<TourReservation> GetAllTourReservations();
        public List<TourReservation> GetByTour(Tour tour);
        public List<TourReservation> GetByTourist(int touristId);
        public TourReservation GetByNotification(int notificationId);
        public void UpdateAttendance(int tourReservationId);

    }
}

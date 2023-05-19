using InitialProject.Interfaces;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class TourReservationService
    {
        private readonly ITourReservationRepository TourReservationRepository;

        public TourReservationService(ITourReservationRepository tourReservationRepository)
        {
            TourReservationRepository = tourReservationRepository;
        }

        public List<TourReservation> GetByTour(Tour tour)
        {
            return TourReservationRepository.GetByTour(tour);
        }

        public List<TourReservation> GetByTourist(int touristId)
        {
            return TourReservationRepository.GetByTourist(touristId);
        }


        public TourReservation GetByNotification(int notificationId)
        {
            return TourReservationRepository.GetByNotification(notificationId);
        }

        public void UpdateAttendance(int tourReservationId)
        {
            TourReservationRepository.UpdateAttendance(tourReservationId);
        }


    }
}

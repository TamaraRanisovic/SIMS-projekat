using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class AccomodationReservationService
    {
        public AccomodationReservationService() { } 

        AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();
        DateTime todaysDate = DateTime.UtcNow.Date;

        public List<AccomodationReservation> GetAllExpired()
        {
           return  accomodationReservationRepository.GetAllExpiredBy(todaysDate.Day, todaysDate.Month, todaysDate.Year); 
        }
    }
}

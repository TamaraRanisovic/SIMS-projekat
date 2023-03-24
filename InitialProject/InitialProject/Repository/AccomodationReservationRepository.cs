using InitialProject.Model;
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
    }
}

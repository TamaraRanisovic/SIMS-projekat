
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace InitialProject.Model
{
    public class AccomodationReservation
    {
        [Key]
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int NumberOfGuests { get; set; }

        public List<Accomodation> Accomodations { get; set; }
        public User User { get; set; }

        public bool Cancelled { get; set; }

        public int AccomodationId { get; set; }



        public AccomodationReservation()
        {

            Accomodations = new List<Accomodation>();
        }

        public AccomodationReservation(DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberOfGuests = numberOfGuests;

            Accomodations = new List<Accomodation>();
        }

        public override string ToString()
        {
            return $"[==========****************===========]\nID: {Id}\n, StartDate: {CheckInDate}\n, EndDate: {CheckOutDate}\n, NumberOfGuests: {NumberOfGuests}\n, AccId: {AccomodationId}\n";
        }

    }
}






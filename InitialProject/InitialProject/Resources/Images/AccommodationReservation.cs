using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Resources.Images
{
    public class AccommodationReservation
    {
        [Key]
        public int Id { get; set; }
        
        public int AccId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int NumberOfGuests { get; set; }

        public User User { get; set; }

        public bool Cancelled { get; set; }

        

        public override string ToString()
        {
            return "CheckIn " + CheckInDate + " CheckOut " + CheckOutDate + " NumberofGuests " + NumberOfGuests;
        }

        public AccommodationReservation()
        {

            
        }

        public AccommodationReservation(DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
        {
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            NumberOfGuests = numberOfGuests;

            
        }
    }
}

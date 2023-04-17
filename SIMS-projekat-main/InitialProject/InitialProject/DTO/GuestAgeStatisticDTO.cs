using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class GuestAgeStatisticDTO
    {   

        public int TourId { get; set; }
        public string Name { get; set; }

        public double Under18 { get; set; }

        public double Beetween18and50 { get; set; }

        public double Above50 { get; set; }
        public GuestAgeStatisticDTO() { }

        public GuestAgeStatisticDTO(int tourId, string name, double under18, double beetween18and50, double above50)
        {
            TourId = tourId;
            Name = name;
            Under18 = under18;
            Beetween18and50 = beetween18and50;
            Above50 = above50;
        }
    }
}

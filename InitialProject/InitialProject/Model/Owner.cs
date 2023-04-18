using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Owner : User
    {
        public List<GuestRating> GuestRatings { get; set; }

        public List<Accomodation> Accomodations { get; set; }

        public Owner()
        {
            GuestRatings = new List<GuestRating>();
            Accomodations = new List<Accomodation>();
        }

        public Owner(string username, string password, UserType userType) : base (username, password, userType) 
        {
            GuestRatings = new List<GuestRating>();
            Accomodations = new List<Accomodation>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace InitialProject.Model
{
    public class Tourist : User
    {
        

        public bool IsPresent { get; set; }

        public List<TourReservation> TourReservations { get; set; }


        public Tourist(string username, string password, UserType userType) : base(username, password, userType)
        {
            TourReservations = new List<TourReservation>();
        }
        public Tourist(string username, string password, UserType userType, bool isPresent) : base(username, password, userType)
        {
            IsPresent = isPresent;
            TourReservations = new List<TourReservation>();
        }

        public override string ToString()
        {
            return $"Id: {Id}\n, Username: {Username}\n, Password: {Password}\n, UserType: {UserType}\n, IsPresent: {IsPresent}\n";
        }
    }
}

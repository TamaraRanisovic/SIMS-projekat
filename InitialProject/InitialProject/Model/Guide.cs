using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class Guide : User
    {

        public List<Tour> Tours { get; set; }
        public List<TourRequest> TourRequests { get; set; }

        public Guide()
        {
            Tours = new List<Tour>();
            TourRequests = new List<TourRequest>();

        }

        public Guide(string username, string password, UserType userType) : base(username, password, userType) 
        {
            Tours = new List<Tour>();
            TourRequests = new List<TourRequest>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Guest : User
    {
        public List<Accomodation> Accomodations { get; set; }

        public List<Comment> Comments { get; set; }

        public Guest()
        {
            Accomodations = new List<Accomodation>();
            Comments = new List<Comment>();
        }

        public Guest(string username, string password, UserType userType) : base(username, password, userType) 
        {
            Accomodations = new List<Accomodation>();
            Comments = new List<Comment>();

        }


    }
}

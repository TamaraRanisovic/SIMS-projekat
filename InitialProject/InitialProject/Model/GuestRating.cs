using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class GuestRating
    {
        public int OwnerUserId { get; set; }

        public DateTime RatingExperationDate { get; set; } //string comment

        public int Cleanliness { get; set; }

        public int RuleCompliance { get; set; } 

        public AccomodationReservation AccomodationReservation { get; set; }

<<<<<<< Updated upstream
        public GuestRating(int id, DateTime ratingExperationDate, int cleanliness, int ruleCompliance)
        {
            Id = id;
            RatingExperationDate = ratingExperationDate;
            Cleanliness = cleanliness;
            RuleCompliance = ruleCompliance;
            
=======

        public GuestRating(int cleanliness, int ruleCompliance, AccomodationReservation accomodationReservation)
        {
            Cleanliness = cleanliness; 
            RuleCompliance = ruleCompliance; 
            AccomodationReservation = accomodationReservation;
>>>>>>> Stashed changes
        }

        public GuestRating(DateTime ratingExperationDate, int cleanliness, int ruleCompliance)
        {
            RatingExperationDate = ratingExperationDate;
            Cleanliness = cleanliness;
            RuleCompliance = ruleCompliance;
            
        }
    }
}

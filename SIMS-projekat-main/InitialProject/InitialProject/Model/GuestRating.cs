﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class GuestRating
    {
        public int Id { get; set; }

        public DateTime RatingExperationDate { get; set; }

        public int Cleanliness { get; set; }

        public int RuleCompliance { get; set; } 

        public AccomodationReservation AccomodationReservation { get; set; }
 
        public GuestRating(DateTime ratingExperationDate, int cleanliness, int ruleCompliance)
        {
            RatingExperationDate = ratingExperationDate;
            Cleanliness = cleanliness;
            RuleCompliance = ruleCompliance;
            
        }
       
    }
}
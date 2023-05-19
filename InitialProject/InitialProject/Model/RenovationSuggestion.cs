using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class RenovationSuggestion
    {
        
            [Key]
            
            public int Id { get; set; }

            public int RenovationRating { get; set; }

            public string Comment { get; set; } = new("");

            
            public AccomodationReservation AccomodationReservation { get; set; }

            public RenovationSuggestion()
            {
                AccomodationReservation = new();
            }

            public RenovationSuggestion(int renovationRating, string comment, AccomodationReservation accomodationReservation)
            {
                RenovationRating = renovationRating;
                Comment = comment;
                AccomodationReservation = accomodationReservation;
            }
        

    }
}

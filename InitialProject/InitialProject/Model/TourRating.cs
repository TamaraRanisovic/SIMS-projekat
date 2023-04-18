using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class TourRating
    {
        [Key]
        public int Id { get; set; }
        public int GuideKnowledge { get; set; }

        public int GuideLanguage { get; set; } 
        
        public int TourAmusement { get; set; }

        public string Comment { get; set; }

        public List<TourImages> TourImages { get; set; }

        public TourRating()
        {
            TourImages = new List<TourImages>();
        }

        public TourRating(int guideKnowledge, int guideLanguage, int tourAmusement, string comment, List<TourImages> tourImages)
        {
            GuideKnowledge = guideKnowledge;
            GuideLanguage = guideLanguage;
            TourAmusement = tourAmusement;
            Comment = comment;
            TourImages = tourImages;
        }


    }
}

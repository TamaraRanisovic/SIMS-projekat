using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class TourRating
    {
        [Key]
        public int Id { get; set; }

        public int TouristId { get; set; }
        public int GuideKnowledge { get; set; } = 0;

        public int GuideLanguage { get; set; } = 0;
        
        public int TourAmusement { get; set; } = 0;

        public string Comment { get; set; } = "";

        public bool IsValid { get; set; }   

        public List<TourImages> TourImages { get; set; }

        public TourRating()
        {
            TourImages = new List<TourImage>();
        }
        public TourRating(int guideKnowledge, int guideLanguage, int tourAmusement, string comment, List<TourImage> tourImages)
        {   
            GuideKnowledge = guideKnowledge;
            GuideLanguage = guideLanguage;
            TourAmusement = tourAmusement;
            Comment = comment;
            TourImages = tourImages;
            IsValid = true;
            
        }
        public TourRating(int touristId,int guideKnowledge, int guideLanguage, int tourAmusement, string comment, List<TourImage> tourImages)
        {   
            TouristId = touristId;
            GuideKnowledge = guideKnowledge;
            GuideLanguage = guideLanguage;
            TourAmusement = tourAmusement;
            Comment = comment;
            TourImages = tourImages;
            IsValid = true;

        }
        public TourRating(int touristId, int guideKnowledge, int guideLanguage, int tourAmusement, string comment, bool valid)
        {
            TouristId = touristId;
            GuideKnowledge = guideKnowledge;
            GuideLanguage = guideLanguage;
            TourAmusement = tourAmusement;
            Comment = comment;
            TourImages = new List<TourImages>();
            IsValid = valid;

        }



    }
}

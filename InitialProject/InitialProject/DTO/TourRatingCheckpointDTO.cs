using InitialProject.Migrations;
using InitialProject.Model;
using System;
using InitialProject.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;
using System.ComponentModel.DataAnnotations;

namespace InitialProject.DTO
{
    public class TourRatingCheckpointDTO 
    {
        public int TouristId { get; set; }
        public string Tourist { get; set; }

        public int GuideKnowledge { get; set; }

        public int GuideLanguage { get; set; }

        public int TourAmusement { get; set; }

        public string Comment { get; set; }

        public string CheckpointName { get; set; }

        public string IsValid { get; set; }

        public int DateId { get; set; }

        public TourRatingCheckpointDTO() { }

        public TourRatingCheckpointDTO(int guideKnowledge, int guideLanguage, int tourAmusement, string comment, string checkpoint, string valid, int dateId, string tourist, int touristId)
        {
            GuideKnowledge = guideKnowledge;
            GuideLanguage = guideLanguage;
            TourAmusement = tourAmusement;
            Comment = comment;
            CheckpointName = checkpoint;
            IsValid = valid;
            DateId = dateId;
            Tourist = tourist;
            TouristId = touristId;
        }

    }
}

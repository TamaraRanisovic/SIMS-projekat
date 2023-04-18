using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using WebApi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace InitialProject.Service
{
    public class K2_F3_Guide
    {
        TourRepository tourRepository = new TourRepository();
        DatesRepository datesRepository = new DatesRepository();
        TouristsRepository touristsRepository = new TouristsRepository();
        CheckpointRepository checkpointRepository = new CheckpointRepository();
        public List<TourRatingCheckpointDTO> ShowReview(int dateId)
        {
            
            DatesRepository datesRepository = new DatesRepository();
            Dates date = datesRepository.GetById(dateId);
            List<Checkpoint> checkpoints = checkpointRepository.GetAllCheckpoints();
            List<TourRating> ratings = new List<TourRating>();
            List<TourRatingCheckpointDTO> toursToReturn = new List<TourRatingCheckpointDTO>();

            if (date == null) return null;

            foreach (var tourist in date.tourists)
            {
                foreach(var rating in tourist.Ratings)
                {
                    TourRating tourRating = new TourRating(tourist.Id, rating.GuideKnowledge, rating.GuideLanguage, rating.TourAmusement, rating.Comment);
                    ratings.Add(tourRating);
                }
            }

            foreach(var checkpoint in checkpoints)
            {
                foreach(var tourist in checkpoint.Tourists)
                {
                    foreach(var tourRating in ratings)
                    {
                        if(tourRating.TouristId == tourist.Id)
                        {
                            TourRatingCheckpointDTO tourRatingCheckpointDTO = new TourRatingCheckpointDTO(tourRating.GuideKnowledge, tourRating.GuideLanguage, tourRating.TourAmusement, tourRating.Comment, checkpoint.Name);
                            toursToReturn.Add(tourRatingCheckpointDTO);
                        }
                    }
                }
            }

            return toursToReturn;
        }



    }
}

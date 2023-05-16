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
    public class ReviewService
    {
        public TourRepository tourRepository = new TourRepository();
        public DatesRepository datesRepository = new DatesRepository();
        public TouristsRepository touristsRepository = new TouristsRepository();
        public CheckpointRepository checkpointRepository = new CheckpointRepository();
        public TourRatingRepository tourRatingRepository = new TourRatingRepository();
        public List<TourRatingCheckpointDTO> ShowReview(int dateId)
        {
            
            DatesRepository datesRepository = new DatesRepository();

            Dates date = datesRepository.GetByIdRatings(dateId);
            List<Checkpoint> checkpoints = checkpointRepository.GetAllCheckpoints();

            List<TourRating> ratings = new List<TourRating>();
            List<TourRatingCheckpointDTO> toursToReturn = new List<TourRatingCheckpointDTO>();

            if (date == null) return null;

            Ratings(date, ref ratings);

            MakeRatingsToReturn(checkpoints, ratings, ref toursToReturn, date);
            
            
            return toursToReturn;
        }

        public void Ratings(Dates date, ref List<TourRating> ratings)
        {
            foreach (var tourist in date.Tourists)
            {
                IterateToMakeRating(tourist, ref ratings);
            }
        }

        public void IterateToMakeRating(Tourist tourist, ref List<TourRating> ratings)
        {
            foreach (var rating in tourist.TourRatings)
            {
                MakeRating(tourist, rating, ref ratings);
            }
        }

        public void MakeRating(Tourist tourist, TourRating rating, ref List<TourRating> ratings)
        {
            TourRating tourRating = new TourRating(tourist.Id, rating.GuideKnowledge, rating.GuideLanguage, rating.TourAmusement, rating.Comment, rating.IsValid);
            ratings.Add(tourRating);
        }

        public void MakeRatingsToReturn(List<Checkpoint> checkpoints, List<TourRating> ratings, ref List<TourRatingCheckpointDTO> toursToReturn, Dates date)
        {

            foreach (var checkpoint in checkpoints)
            {
                IterateTourists(checkpoint.Tourists, ref toursToReturn, checkpoint, ratings, date);
                
            }

            
        }

        public void IterateTourists(List<Tourist> tourists, ref List<TourRatingCheckpointDTO> toursToReturn, Checkpoint checkpoint, List<TourRating> ratings, Dates date)
        {
            foreach (var tourist in checkpoint.Tourists)
            {
                IterateRatings(ref toursToReturn, ratings, tourist, checkpoint, date);
            }
            
        }

        public void IterateRatings(ref List<TourRatingCheckpointDTO> toursToReturn, List<TourRating> ratings, Tourist tourist, Checkpoint checkpoint, Dates date)
        {
            foreach (var tourRating in ratings)
            {
                if (tourRating.TouristId == tourist.Id)
                {
                    MakeTourRating(tourRating, checkpoint, ref toursToReturn, date, tourist);
                }
            }
        }

        public void MakeTourRating(TourRating tourRating, Checkpoint checkpoint, ref List<TourRatingCheckpointDTO> toursToReturn, Dates date, Tourist tourist)
        {
            if (tourRating.IsValid)
            {
                TourRatingCheckpointDTO tourRatingCheckpointDTO = new TourRatingCheckpointDTO(tourRating.GuideKnowledge, tourRating.GuideLanguage, tourRating.TourAmusement, tourRating.Comment, checkpoint.Name, "validna", date.Id, tourist.Username, tourist.Id);
                toursToReturn.Add(tourRatingCheckpointDTO);
            } else
            {
                TourRatingCheckpointDTO tourRatingCheckpointDTO = new TourRatingCheckpointDTO(tourRating.GuideKnowledge, tourRating.GuideLanguage, tourRating.TourAmusement, tourRating.Comment, checkpoint.Name, "nevalidna", date.Id, tourist.Username, tourist.Id);
                toursToReturn.Add(tourRatingCheckpointDTO);
            }
            
        }

        public bool UnvalidRating(TourRatingCheckpointDTO rating)
        {
            if (rating.IsValid == "validna")
            {
                int dateId = rating.DateId;
                bool valid = false;

                tourRatingRepository.Update(rating, dateId, valid);
                return true;

            }
            return false;
        }
    }
}

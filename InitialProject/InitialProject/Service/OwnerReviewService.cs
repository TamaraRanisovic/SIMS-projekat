﻿using InitialProject.Interface;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class OwnerReviewService
    {
        private readonly IOwnerReviewRepository IOwnerReviewRepository;
        private GuestRatingService GuestRatingService;
        private UserService UserService = new UserService(new UserRepository());
        private AccomodationService AccomodationService = new AccomodationService();

        public OwnerReviewService(IOwnerReviewRepository iOwnerReviewRepository)
        {
            this.IOwnerReviewRepository = iOwnerReviewRepository;
            this.GuestRatingService = new GuestRatingService();
        }

        public List<OwnerReview> GetAllOwnerReviews()
        {
            return this.IOwnerReviewRepository.GetAllOwnerReviews();
        }

        public List<OwnerReview> GetAllGraded()
        {
            List <AccomodationReservation> gradedReservations = new List<AccomodationReservation> ();

            gradedReservations = GuestRatingService.GetGradedReservations(); 

            List<OwnerReview> ownerReviews = new List<OwnerReview> (); 

            foreach (var review in GetAllOwnerReviews())
            {
                foreach(var reservation in gradedReservations)
                {
                    if (reservation.Id == review.AccomodationReservation.Id)
                    {
                        ownerReviews.Add(review);
                    }
                }
            }
            return ownerReviews;


        }

        public void DeclareOwner(bool superOwner)
        {
            this.UserService.UpdateStatus(superOwner);
            this.AccomodationService.UpdateClassBy(superOwner);
        }


    }
}

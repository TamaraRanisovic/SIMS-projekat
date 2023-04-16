﻿using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class K2_F2_Guide
    {   
        TourRepository tourRepository = new TourRepository();
        DatesRepository datesRepository = new DatesRepository();
        public TourDateDTO ShowMostVisitedTour(List<Dates> dates)
        {
            int mostVisitedDateId = FindMostVisitedDateId(dates);
            List<Tour> tours = tourRepository.GetAll();
            Tour tour = FindMostVisitedTourName(tours, mostVisitedDateId);
            Dates date = datesRepository.GetById(mostVisitedDateId);

            TourDateDTO tourDateDTO = new TourDateDTO(tour.TourId,tour.Name, date.Date, date.Id, tour.Description);

            return tourDateDTO;
        }
        
        public TourDateDTO ShowMostVisitedByYear(int year)
        {
            List<Dates> dates = datesRepository.GetByYear(year);
            TourDateDTO tourToReturn = ShowMostVisitedTour(dates);
            return tourToReturn;
        }

        public void TouristsStat(string dateName)
        {

        }
        public int FindMostVisitedDateId(List<Dates> dates)
        {
            int max = 0;
            int maxDateId = 0;
            foreach (var date in dates)
            {
                int brojacTurista = 0;
                foreach (var tourist in date.tourists)
                {
                    brojacTurista++;

                }

                if (brojacTurista > max)
                {
                    max = brojacTurista;
                    maxDateId = date.Id;
                }
                
            }
            return maxDateId;
        }

        public Tour FindMostVisitedTourName(List<Tour> tours, int dateId)
        {
            foreach(var tour in tours)
            {
                foreach (var date in tour.StartingDates)
                {
                    if(date.Id == dateId)
                    {
                        return tour;
                    }
                }
            }
            return null;
        }
        public List<TourDateDTO> FinishedTours()
        {
            List<Tour> Tour = tourRepository.GetAll();
            List<TourDateDTO> toursToReturn = new List<TourDateDTO>();
            DateTime currentTime = DateTime.Now;
            foreach (var tour in Tour)
            {
                foreach (var date in tour.StartingDates)
                {
                    DateTime finishDate = date.Date.AddHours(tour.Duration);
                    if (DateTime.Compare(finishDate, currentTime) < 0)
                    {
                        TourDateDTO tourDate = new TourDateDTO(tour.TourId, tour.Name, date.Date, date.Id, tour.Description);
                        toursToReturn.Add(tourDate);
                    }
                }
            }
            return toursToReturn;
        }
    }
}
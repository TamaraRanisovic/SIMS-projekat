using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class AccomodationService
    {
        public AccomodationService()
        {

        }
        AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();
        AccomodationRepository accomodationRepository = new AccomodationRepository();
        LocationRepository locationRepository = new LocationRepository();
        AccomodationReservationService accomodationReservationService = new AccomodationReservationService(); 
        ReservationReschedulingRequestService reservationReschedulingRequestService = new ReservationReschedulingRequestService();
        RenovationSuggestionService renovationSuggestionService = new RenovationSuggestionService();

        public void RegisterAccomodation(Accomodation accomodation, Location location, List<AccomodationImage> accomodationImages)
        {
            using (var context = new DataContext())
            {
                Location existingLocation = locationRepository.GetLocationByCityAndCountry(location.City, location.Country);

                if (existingLocation != null)
                {
                    location = existingLocation;
                    location.Accomodations.Add(accomodation);
                    context.Locations.Update(location);
                }
                else
                {
                    location.Accomodations.Add(accomodation);
                    context.Locations.Add(location);
                }

                foreach (var image in accomodationImages)
                {
                    context.AccomodationImages.Add(image);
                    accomodation.Images.Add(image);
                }
                context.SaveChanges();

            }

        }

        public void UpdateClassBy(bool superOwner)
        {
            string accomodationClass = "B";

            if(superOwner)
            {
                accomodationClass = "A";
            }

            this.accomodationRepository.UpdateClassBy(accomodationClass);
        }

        public List<DateSuggestion> GetRenovationDateSuggestions (Accomodation accomodation, DateTime desiredStart, DateTime desiredEnd, TimeSpan desiredDuration)
        {
            List<DateSuggestion> renovationDatesSuggestions = new List<DateSuggestion>();

            List<AccomodationReservation> preservedRenovations = new List<AccomodationReservation>();
            DateTime startPoint = desiredStart;
            DateTime limit;
            DateTime endPoint;
            TimeSpan day = new System.TimeSpan(1, 0, 0, 0);

            preservedRenovations = accomodationReservationRepository.GetAllBetween(desiredStart, desiredEnd);

            foreach(var reservation in preservedRenovations)
            {
                DateTime checkpoint = startPoint.Add(desiredDuration);

                if (checkpoint <= desiredEnd)
                {
                    if (startPoint < reservation.CheckInDate)
                    {
                        endPoint = startPoint.Add(desiredDuration);

                        if ( endPoint < reservation.CheckInDate) 
                        {
                            limit = reservation.CheckInDate.Subtract(day);

                            while(endPoint <= limit)
                            {
                                DateSuggestion dateSuggestion = new DateSuggestion(startPoint, endPoint);
                                renovationDatesSuggestions.Add(dateSuggestion);

                                startPoint = startPoint.Add(day);
                                endPoint = endPoint.Add(day);
                            }

                            startPoint = reservation.CheckInDate;
                        }
                        else
                        {
                            startPoint = reservation.CheckInDate;
                        }
                    }

                    if (startPoint >= reservation.CheckInDate)
                    {
                        startPoint = reservation.CheckOutDate;
                        startPoint = startPoint.Add(day);
                    }
                }
            }

            endPoint = startPoint.Add(desiredDuration);
            while(endPoint <= desiredEnd)
            {
                DateSuggestion dateSuggestion = new DateSuggestion(startPoint, endPoint);
                renovationDatesSuggestions.Add(dateSuggestion);

                startPoint = startPoint.Add(day);
                endPoint = endPoint.Add(day);
            }

            return renovationDatesSuggestions;
        }

        public List<Statistics> GetAnnualStatisticsBy(Accomodation accommodation)
        {

            List<Statistics> yearStatistics = new List<Statistics>();

            List<int> yearsSample = new List<int>();

            int reservationCount, cancellationCount, reschedulingCount, renovationSuggestionCount;

            double occupancy;


            // yearsSample = accomodationReservationService.GetReservationYearsBy(accommodation);

            //yearsSample.Sort();

            for (int year = 2022; year <= 2024; year++)
            {

                reservationCount = accomodationReservationService.GetCountBy(year, accommodation);

                cancellationCount = accomodationReservationService.GetCancellationCountBy(year, accommodation);

                reschedulingCount = reservationReschedulingRequestService.GetCountBy(year, accommodation);

                renovationSuggestionCount = renovationSuggestionService.GetCountBy(year, accommodation);

                occupancy = accomodationReservationService.GetOccupancyBy(year, accommodation);


                Statistics statistics = new Statistics(reservationCount, year.ToString(), cancellationCount, reschedulingCount, renovationSuggestionCount, occupancy);

                yearStatistics.Add(statistics);
            }

            return yearStatistics;
        }

        private string ToMonth(int month)
        {

            if (month == 1)
            {
                return "JAN";
            }
            if (month == 2)
            {
                return "FEB";
            }
            if (month == 3)
            {
                return "MAR";
            }
            if (month == 4)
            {
                return "APR";
            }
            if (month == 5)
            {
                return "MAY";
            }
            if (month == 6)
            {
                return "JUN";
            }
            if (month == 7)
            {
                return "JULY";
            }
            if (month == 8)
            {
                return "AUG";
            }
            if (month == 9)
            {
                return "SEP";
            }
            if (month == 10)
            {
                return "OCT";
            }
            if (month == 11)
            {
                return "NOV";
            }
            return "DEC";
        }

        public List<Statistics> GetMonthsStatisticsBy(int year, Accomodation accommodation)
        {

            List<Statistics> monthStatistics = new List<Statistics>();

            int reservationCount, cancellationCount, reschedulingCount, renovationSuggestionCount;

            double occupancy;

            for (int month = 1; month <= 12; month++)
            {
                reservationCount =  accomodationReservationService.GetCountBy(year, month, accommodation);

                cancellationCount = accomodationReservationService.GetCancellationCountBy(year, month, accommodation);

                reschedulingCount = reservationReschedulingRequestService.GetCountBy(year, month, accommodation);

                renovationSuggestionCount = renovationSuggestionService.GetCountBy(year, month, accommodation);

                occupancy = accomodationReservationService.GetOccupancyBy(year, month, accommodation);

                Statistics statistics = new Statistics(reservationCount, ToMonth(month), cancellationCount, reschedulingCount, renovationSuggestionCount, occupancy);

                monthStatistics.Add(statistics);

            }

            return monthStatistics;
        }

    }
}

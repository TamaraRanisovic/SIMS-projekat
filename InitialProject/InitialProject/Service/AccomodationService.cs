using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.Repository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                AccomodationRepository accomodationRepository = new AccomodationRepository();
                accomodationRepository.GetAllAccomodations();
            }
   
        }

       /* public List<Accomodation> GetAccomodationsByLocation(int locationId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> accomodationsByLocation = accomodationRepository.GetAccomodationsByLocation(locationId);
            return accomodationsByLocation;
        }*/

        public Accomodation GetAccomodationById(int accId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            return accomodationRepository.GetAccomodationById(accId);
        }

       

        public void UpdateClassBy(bool superOwner)
        {
            string accomodationClass = "B";

            if (superOwner)
            {
                accomodationClass = "A";
            }

            this.accomodationRepository.UpdateClassBy(accomodationClass);
        }

        public List<DateSuggestion> GetRenovationDateSuggestions(Accomodation accomodation, DateTime desiredStart, DateTime desiredEnd, TimeSpan desiredDuration)
        {
            List<DateSuggestion> renovationDatesSuggestions = new List<DateSuggestion>();

            List<AccomodationReservation> preservedRenovations = new List<AccomodationReservation>();
            DateTime startPoint = desiredStart;
            DateTime limit;
            DateTime endPoint;
            TimeSpan day = new System.TimeSpan(1, 0, 0, 0);

            preservedRenovations = accomodationReservationRepository.GetAllBetween(desiredStart, desiredEnd);

            foreach (var reservation in preservedRenovations)
            {
                DateTime checkpoint = startPoint.Add(desiredDuration);

                if (checkpoint <= desiredEnd)
                {
                    if (startPoint < reservation.CheckInDate)
                    {
                        endPoint = startPoint.Add(desiredDuration);

                        if (endPoint < reservation.CheckInDate)
                        {
                            limit = reservation.CheckInDate.Subtract(day);

                            while (endPoint <= limit)
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
            while (endPoint <= desiredEnd)
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
                reservationCount = accomodationReservationService.GetCountBy(year, month, accommodation);

                cancellationCount = accomodationReservationService.GetCancellationCountBy(year, month, accommodation);

                reschedulingCount = reservationReschedulingRequestService.GetCountBy(year, month, accommodation);

                renovationSuggestionCount = renovationSuggestionService.GetCountBy(year, month, accommodation);

                occupancy = accomodationReservationService.GetOccupancyBy(year, month, accommodation);

                Statistics statistics = new Statistics(reservationCount, ToMonth(month), cancellationCount, reschedulingCount, renovationSuggestionCount, occupancy);

                monthStatistics.Add(statistics);

            }

            return monthStatistics;
        }
        public void UpdateAvailability(int accId, DateTime start, DateTime end, int numberOfGuests)
        {
            using (var db = new DataContext())
            {
                var accomodation = GetAccomodationById(accId);
                if (accomodation == null)
                {
                    Console.WriteLine("Accomodation not found.");
                    return;
                }
                if (accomodation.MaxGuests < numberOfGuests)
                {
                    Console.WriteLine("Not enough spots available for the given number of guests");
                    return;
                }

                accomodation.MaxGuests = numberOfGuests;
                db.SaveChanges();
            }
        }


        public List<Accomodation> FindAvailableAccomodations(DateTime startDate, DateTime endDate, int numberOfGuests)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> availableAccomodations = new List<Accomodation>();
            foreach (Accomodation accomodation in accomodationRepository.GetAllAccomodations())
            {
                if ((endDate - startDate).Days + 1 > accomodation.MinReservationDays)
                {
                    if (GetFreeSpotsNumber(accomodation.Id) >= numberOfGuests) //&& accomodation.IsAvailable
                    {
                        availableAccomodations.Add(accomodation);
                    }
                }
            }
            return availableAccomodations;
        }

        public List<Guest> GetGuests(int accId)
        {
            GuestsRepository guestsRepository = new GuestsRepository();
            return guestsRepository.GetGuests(accId);
        }

        public int GetFreeSpotsNumber(int accId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            Accomodation accomodation = GetAccomodationById(accId);
            List<Guest> accomodationsGuests = new List<Guest>();
            accomodationsGuests = GetGuests(accId);
            int freeSpotsNumber = accomodation.MaxGuests - accomodationRepository.GetNumberOfGuestsInAccomodation(accId);
            return freeSpotsNumber;
        }


        public void BookAcc(int accId, int guestsId, int guestsNumber, DateTime start, DateTime end)
        {
            AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();
            accomodationReservationRepository.BookAcc(accId, guestsId, guestsNumber, start, end);
        }



        public bool IsAvailable(DateTime start, DateTime end, Accomodation accomodation)
        {
            var reservations = accomodation.AccomodationReservations;
            return !reservations.Any(r => (start >= r.CheckInDate && start < r.CheckOutDate) || (end > r.CheckInDate && end <= r.CheckOutDate));
        }

        public void CancelReservation(int idRezervacije)                            //!?!?!?!?!?!??!?!?!?!?!
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            AccomodationReservationRepository accomodationReservationRepository = new AccomodationReservationRepository();

            Accomodation accomodation = GetAccomodationById(idRezervacije); //ZAMASKIRANO ID i IDACC u bazi podesavam da je isti to je GRESKA MORA SE SREDITI!!!
            AccomodationReservation accomodationReservation = accomodationReservationRepository.GetAccomodationReservationById(idRezervacije);

            //funkcija za ID dobavljanje

            using (var db = new DataContext())
            {

                if (accomodation.DaysBeforeCanceling > (accomodationReservation.CheckInDate - DateTime.Now).TotalDays)
                {
                    Console.WriteLine("it is impossible to cancel the reservation because the owner has given several days before cancellation");
                    return;
                }
                else if (accomodationReservation.CheckInDate - DateTime.Now < new TimeSpan(24, 0, 0))
                {
                    Console.WriteLine("it is impossible to cancel because there are less than 24 hours until the start of the reservation");
                    return;
                }

                else
                {


                    db.AccomodationReservations.Remove(accomodationReservation);
                    Console.WriteLine("Succesfully removed accomodation reservation!");
                    db.SaveChanges();
                    db.AccomodationReservations.Remove(accomodationReservation);
                    db.SaveChanges();
                    Console.WriteLine("Succesfully removed accomodation reservation!");
                    return;
                }
            }

        }



        // PRAVIM FUNKCIJU ZA RESERVACIJU SKROZ TACNU 
        //Fja za VIEW MODEL
        public void ReserveAccomodation(int AccId, int GuestId, int NumberOfGuests, DateTime DateIn, DateTime DateOut, string username, string password)
        {
            UserService userService = new UserService(new UserRepository());
            Accomodation accomodation = GetAccomodationById(AccId);  //????????????
            AccomodationService accomodationService = new AccomodationService();

            if (userService.Login(username, password) != null)
            {
                Guest guest = (Guest)userService.GetByUsername(username);

                if (guest.UserType == UserType.Guest)
                {
                    if (IsAvailable(DateIn, DateOut, accomodation))
                    {
                        MakeReservation(AccId, GuestId, NumberOfGuests, DateIn, DateOut);
                        MessageBox.Show("Succesfully reserved accomodation!");
                    }
                    else { MessageBox.Show("Zauzet je u tom periodu"); }
                }
                else { MessageBox.Show("Moras jos da mozgas"); }
            }

        }

        // I OVDE ISTO
        // FUNKCIJA ZA REZERVACIJU
        public void MakeReservation(int accId, int guestsId, int numberGuests, DateTime startD, DateTime endD)
        {
            AccomodationService accomodationService = new AccomodationService();
            Accomodation izabran = accomodationService.GetAccomodationById(accId);
            List<Accomodation> availableAccommodation = accomodationService.FindAvailableAccomodations(startD, endD, numberGuests);
            if (availableAccommodation == null)
            {
                throw new Exception("Nema slobodnih.");
            }

            foreach (Accomodation accomodation in availableAccommodation)
            {
                if (accomodation == izabran)
                {
                    accomodationService.BookAcc(accId, guestsId, numberGuests, startD, endD);
                }
            }
            using (var db = new DataContext())
            {
                var reservation = new AccomodationReservation
                {

                    CheckInDate = startD,
                    CheckOutDate = endD,
                    NumberOfGuests = numberGuests,
                    AccomodationId = accId

                };

                //  List<AccomodationReservation> listaRezervisanihId = new List<AccomodationReservation>();
                Accomodation accomodation = accomodationService.GetAccomodationById(accId);
                accomodation.AccomodationReservations.Add(reservation);
                db.AccomodationReservations.Add(reservation);
                db.SaveChanges();
                accomodationService.UpdateAvailability(accId, startD, endD, numberGuests);
                Console.WriteLine("aaa");
            }
        }


    }
}

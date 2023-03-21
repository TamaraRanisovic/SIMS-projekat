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
    public class AccomodationService
    {
        private readonly AccomodationRepository AccomodationRepository;
        private readonly LocationRepository LocationRepository;
        private readonly AccomodationImagesRepository accomodationImagesRepository;


        public AccomodationService() { }

        public AccomodationService(AccomodationRepository accomodationRepository, LocationRepository locationRepository)
        {
            AccomodationRepository = accomodationRepository;
            LocationRepository = locationRepository;
        }


        public List<Accomodation> GetAllAccomodations()
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            return accomodationRepository.GetAllAccomodations();
        }

        public List<Accomodation> GetAccomodationsByLocation(int locationId)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> accomodationsByLocation = accomodationRepository.GetAccomodationsByLocation(locationId);
            return accomodationsByLocation;
        }

        public List<Accomodation> GetByType(string type)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByType = new List<Accomodation>();
            foreach (Accomodation accomodation in allAccomodations)
            {
                if (accomodation.AccomodationType == (AccomodationType)Enum.Parse(typeof(AccomodationType), type))
                {
                    accomodationsByType.Add(accomodation);
                }

            }
            return accomodationsByType;
        }

        public List<Accomodation> GetByName(string name)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByName = new List<Accomodation>();

            foreach (Accomodation accomodation in allAccomodations)
            {
                if (accomodation.Name.Equals(name))
                {
                    accomodationsByName.Add(accomodation);
                }
            }
            return accomodationsByName;
        }

        public List<Accomodation> GetByGuestsNumber(int guestsNumber)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByGuestsNumber = new List<Accomodation>();

            foreach (Accomodation accomodation in allAccomodations)
            {
                if (accomodation.Guests != null)
                {
                    if (accomodation.MaxGuests - accomodation.Guests.Count() >= guestsNumber)
                    {
                        accomodationsByGuestsNumber.Add(accomodation);
                    }
                }
                else
                {
                    if (accomodation.MaxGuests >= guestsNumber)
                    {
                        accomodationsByGuestsNumber.Add(accomodation);
                    }
                }
            }
            return accomodationsByGuestsNumber;

        }

        public List<Accomodation> GetByReservationDays(int reservationDays)
        {
            AccomodationRepository accomodationRepository = new AccomodationRepository();
            List<Accomodation> allAccomodations = accomodationRepository.GetAllAccomodations();
            List<Accomodation> accomodationsByReservationDays = new List<Accomodation>();

            foreach (Accomodation accomodation in allAccomodations)
            {
                if (reservationDays >= accomodation.MinReservationDays)
                {
                    accomodationsByReservationDays.Add(accomodation);
                }
            }
            return accomodationsByReservationDays;
        }


        public Location GetAccomodationLocation(int accId)
        {
            LocationRepository locationRepository = new LocationRepository();
            List<Location> allLocations = locationRepository.GetAllLocations();
            List<Accomodation> accomodationsByLocation = new List<Accomodation>();

            foreach (Location location in allLocations)
            {
                accomodationsByLocation = GetAccomodationsByLocation(location.LocationId);
                foreach (Accomodation accomodation in accomodationsByLocation)
                {
                    if (accomodation.AccId == accId)
                    {
                        return location;
                    }
                }
            }
            return null;
        }


    }
}

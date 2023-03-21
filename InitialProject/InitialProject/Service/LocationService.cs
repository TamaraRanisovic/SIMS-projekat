using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class LocationService
    {
        private readonly LocationRepository LocationRepository;
        public LocationService()
        {
            
        }

        public LocationService(LocationRepository locationRepository)
        {
            LocationRepository = locationRepository;
        }

        public List<Location> GetAllLocations()
        {
            LocationRepository locationRepository = new LocationRepository();
            return locationRepository.GetAllLocations();
        }

        public Location GetLocationByCityAndCountry(string city, string country)
        {
            LocationRepository locationRepository = new LocationRepository();
            return locationRepository.GetLocationByCityAndCountry(city, country);
        }

    }
}

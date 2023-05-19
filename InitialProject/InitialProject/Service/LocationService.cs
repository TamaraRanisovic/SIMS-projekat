using InitialProject.Interfaces;
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

        private readonly ILocationRepository LocationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            LocationRepository = locationRepository;
        }

        public List<Location> GetAllLocations()
        {
            return LocationRepository.GetAll();
        }

        public Location GetByCityAndCountry(string city, string country)
        {
            return LocationRepository.GetByCityAndCountry(city, country);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class LocationDTO
    {
        public string City {  get; set; }  
        public string Country { get; set; } 

        public LocationDTO()
        {
            
        }
        public LocationDTO(string city, string country)
        {
            City = city;
            Country = country;
        }


    }
}

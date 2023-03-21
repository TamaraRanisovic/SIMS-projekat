using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities;

public class Location
{
    [Key]
    public int LocationId { get; set; }
    public string City { get; set; }

    public string Country { get; set; }

    public List<Tour> Tours { get; set; }

    public List<Accomodation> Accomodations { get; set; }
    public Location()
    {
        Tours = new List<Tour>();
        Accomodations = new List<Accomodation>();
    }

    public Location(int locationId, string city, string country)
    {
        LocationId = locationId;
        City = city;
        Country = country;
        Tours = new List<Tour>();
        Accomodations = new List<Accomodation>();

    }
    public Location(string city, string country)
    {
        City = city;
        Country = country;
        Tours = new List<Tour>();
        Accomodations = new List<Accomodation>();

    }
    public Location(int locationId, string city, string country, List<Accomodation> accomodations, List<Tour> tours): this (locationId, city, country)
    {
        Tours = tours;
        Accomodations = accomodations;

    }
}
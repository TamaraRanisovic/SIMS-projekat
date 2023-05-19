
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities;
public class Tour
{
    [Key]
    public int TourId { get; set; }
    public string Name { get; set; }

    public int GuideId { get; set; }
    public string Description { get; set; }

    public string Language { get; set; }

    public int MaxGuests { get; set; }

    public int Duration { get; set; }

    public List<Dates> StartingDates { get; set; }

    public List<TourImage> Images { get; set; }

    public List<Checkpoint> Checkpoints { get; set; }

    public List<Tourist> Tourists { get; set; }

    public List<TourReservation> TourReservations { get; set; }

    public List<TourRating> TourRatings { get; set; }

    public Tour()

    {
        GuideId = UserSession.LoggedInUser.Id;
        Images = new List<TourImage>();
        Checkpoints = new List<Checkpoint>();
        Tourists = new List<Tourist>();
        TourReservations = new List<TourReservation>();
        StartingDates = new List<Dates>();
        TourRatings = new List<TourRating>();

    }

    public Tour(string name, string description, string language, int maxGuests, int duration)
    {
        Name = name;
        Description = description;
        Language = language;
        MaxGuests = maxGuests;
        Duration = duration;
        Images = new List<TourImage>();
        Checkpoints = new List<Checkpoint>();
        Tourists = new List<Tourist>();
        TourReservations = new List<TourReservation>();
        StartingDates = new List<Dates>();
        TourRatings = new List<TourRating>();

    }

    public override string ToString()
    {
        return $"TourId: {TourId}\n, Name: {Name}\n, Description: {Description}\n, Language: {Language}\n, MaxGuests: {MaxGuests}\n, Duration: {Duration}\n";

    }

    public bool Equals(Tour tour)
    {
        if (tour == null) return false;
        return (this.TourId == tour.TourId);
    }
}

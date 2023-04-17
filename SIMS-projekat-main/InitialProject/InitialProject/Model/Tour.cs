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

    public List<TourImages> Images { get; set; }

    public List<Dates> StartingDates { get; set; }

    public List<Checkpoint> Checkpoints { get; set; }

    public List<Tourist> Tourists { get; set; }

    public List<TourReservation> TourReservations { get; set; }

    public Tour() 

    {
        Images = new List<TourImages>();
        Checkpoints = new List<Checkpoint>();
        Tourists = new List<Tourist>();
        TourReservations = new List<TourReservation>();
        StartingDates = new List<Dates>();
    }

    public Tour(int guideId, string name, string description, string language, int maxGuests,int duration)
    {
        Name = name;
        GuideId = guideId;
        Description = description;
        Language = language;
        MaxGuests = maxGuests;
        Duration = duration;
        Images = new List<TourImages>();
        Checkpoints = new List<Checkpoint>();
        Tourists = new List<Tourist>();
        TourReservations = new List<TourReservation>();
        StartingDates = new List<Dates>();
    }

    public override string ToString()
    {
        return $"TourId: {TourId}\n, Name: {Name}\n, Description: {Description}\n, Language: {Language}\n, MaxGuests: {MaxGuests}\n, Duration: {Duration}\n";

    }
}       



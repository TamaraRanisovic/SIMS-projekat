using InitialProject.Model;
using System.Collections.Generic;
using System;

public class AccomodationReservation
{
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; }

    public List<Accomodation> Accomodations { get; set; }  //
    
    //public List<User> Users { get; set; }  

    public AccomodationReservation()
    {
      // Users = new List<User>();
        Accomodations = new List<Accomodation>();
    }

    public AccomodationReservation(int id, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
    {
        Id = id;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        NumberOfGuests = numberOfGuests;
      //  Users = new List<User>();
        Accomodations = new List<Accomodation>();

    }

    public AccomodationReservation(DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
    {
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        NumberOfGuests = numberOfGuests;
        //Users = new List<User>();
        Accomodations = new List<Accomodation>();
    }

}
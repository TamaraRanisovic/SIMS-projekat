using InitialProject.Model;
using System.Collections.Generic;
using System;
<<<<<<< Updated upstream

public class AccomodationReservation
{
=======
using System.ComponentModel.DataAnnotations;

public class AccomodationReservation
{
    [Key]
>>>>>>> Stashed changes
    public int Id { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    public int NumberOfGuests { get; set; }

    public List<Accomodation> Accomodations { get; set; }  //
<<<<<<< Updated upstream
=======

    public int AccomodationId { get; set; }
>>>>>>> Stashed changes
    
   // public List<User> Users { get; set; }  

    public AccomodationReservation()
    { 
       // Users = new List<User>();
        Accomodations = new List<Accomodation>();
    }

<<<<<<< Updated upstream
    public AccomodationReservation(int id, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
    {
        Id = id;
=======
    public AccomodationReservation(int id, DateTime checkInDate, DateTime checkOutDate, int numberOfGuests, int accId)
    {
>>>>>>> Stashed changes
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        NumberOfGuests = numberOfGuests;
      //   Users = new List<User>();
        Accomodations = new List<Accomodation>();
<<<<<<< Updated upstream

    }

    public AccomodationReservation(DateTime checkInDate, DateTime checkOutDate, int numberOfGuests)
    {
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        NumberOfGuests = numberOfGuests;
      //  Users = new List<User>();
        Accomodations = new List<Accomodation>();
    }

}
=======
        AccomodationId = accId;

    }

    public override string ToString()
    {
        return $"[==========****************===========]\nID: {Id}\n, StartDate: {CheckInDate}\n, EndDate: {CheckOutDate}\n, NumberOfGuests: {NumberOfGuests}\n, AccId: {AccomodationId}\n";
    }

}

>>>>>>> Stashed changes

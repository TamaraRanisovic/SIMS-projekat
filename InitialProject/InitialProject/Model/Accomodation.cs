﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class Accomodation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public AccomodationType AccomodationType { get; set; }

        public int MaxGuests { get; set; }

        public int MinReservationDays { get; set; }

        public int DaysBeforeCanceling { get; set; }

        //  public bool IsAvailable { get; set; }

        public List<AccomodationImage> Images { get; set; }

        public List<Guest> Guests { get; set; }


        public string Class { get; set; }


        public List<AccomodationReservation> AccomodationReservations { get; set; }

        public List<Renovation> Renovations { get; set; }

        public bool RecentlyRenovated { get; set; }

        private DateTime _lastRenovation;
        public DateTime LastRenovation
        {
            get { return _lastRenovation; }

            set
            {
                _lastRenovation = value;

                if (LastRenovation != default(DateTime))
                {

                    if (DateTime.UtcNow <= LastRenovation.Add(new TimeSpan(366, 0, 0, 0)))
                    {
                        if (LastRenovation <= DateTime.UtcNow)// < == > if(finished)
                        {
                            this.RecentlyRenovated = true;
                        }
                        else
                        {
                            this.RecentlyRenovated = false;
                        }
                    }
                    else
                    {
                        this.RecentlyRenovated = false;
                    }
                }
                else
                {
                    this.RecentlyRenovated = false;
                }
            }
        }

        public override string ToString()
        {
            return "Name" + Name + "AccomodationType" + AccomodationType + "MaxGuests" + MaxGuests + "MinReservationDays" + MinReservationDays + "DaysBeforeCacneling" + DaysBeforeCanceling + "Images" + Images + "AccReservations" + AccomodationReservations;
        }

        public Accomodation()
        {
            Images = new List<AccomodationImage>();

            AccomodationReservations = new List<AccomodationReservation>();

        }






        public Accomodation(string name, Location location, AccomodationType type, int maxGuests, int minReservationDays, int daysBeforeCanceling)
        {
            Name = name;
            AccomodationType = type;
            MaxGuests = maxGuests;
            MinReservationDays = minReservationDays;
            DaysBeforeCanceling = daysBeforeCanceling;
            Images = new List<AccomodationImage>();

            AccomodationReservations = new List<AccomodationReservation>();

            Guests = new List<Guest>();


        }

    }
}

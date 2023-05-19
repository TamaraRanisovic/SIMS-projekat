﻿using InitialProject.Resources.Images;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Checkpoint> Checkpoints { get; set; }

        public DbSet<Accomodation> Accomodations { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestRating> GuestRatings { get; set; }
        public DbSet<Guide> Guides { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Tourist> Tourists { get; set; }

        public DbSet<AccomodationImage> AccomodationImages { get; set; }

        public DbSet<TourImages> TourImages { get; set; }

        public DbSet<AccomodationReservation> AccomodationReservations { get; set; }


        public DbSet<OwnerReview> OwnerReviews { get; set; }

        public DbSet<ReservationReschedulingRequest> ReservationReschedulingRequests { get; set; }

        public DbSet<Renovation> Renovations { get; set; }

        public DbSet<RenovationSuggestion> RenovationSuggestions { get; set; } 

        public DbSet<AccommodationReservation> AccommodationReservations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tura
            modelBuilder.Entity<TourImages>()
                .HasOne<Tour>()
                .WithMany(t => t.Images)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Checkpoint>()
                .HasOne<Tour>()
                .WithMany(t => t.Checkpoints)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tourist>()
                .HasOne<Tour>()
                .WithMany(t => t.Tourists)
                .OnDelete(DeleteBehavior.Cascade);

            //Accomodations check
            modelBuilder.Entity<AccomodationImage>()
                .HasOne<Accomodation>()
                .WithMany(t => t.Images)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccomodationReservation>()
               .HasOne<Accomodation>()
               .WithMany(t => t.AccomodationReservations)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccomodationReservation>()
              .HasOne<Accomodation>()
              .WithMany(t => t.AccomodationReservations)
              .OnDelete(DeleteBehavior.Restrict);

            // modelBuilder.Entity<AccomodationReservation>()
            // .HasOne<Guest>()
            // .WithMany(t => t.AccomodationReservations)
            //.OnDelete(DeleteBehavior.Cascade);

            /* modelBuilder.Entity<Guest>()
                .HasOne<Accomodation>()
                .WithMany(t => t.Guests)
                .OnDelete(DeleteBehavior.Cascade);*/

            //Checkpoint

            modelBuilder.Entity<Tourist>()
                .HasOne<Checkpoint>()
                .WithMany(t => t.Tourists)
                .OnDelete(DeleteBehavior.Cascade);

            //Guest
            modelBuilder.Entity<Accomodation>()
                .HasOne<Guest>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne<Guest>()
                .WithMany(t => t.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            //Guide
            modelBuilder.Entity<Tour>()
                .HasOne<Guide>()
                .WithMany(t => t.Tours)
                .OnDelete(DeleteBehavior.Cascade);

            //Lokacija

            modelBuilder.Entity<Accomodation>()
                .HasOne<Location>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tour>()
                .HasOne<Location>()
                .WithMany(t => t.Tours)
                .OnDelete(DeleteBehavior.Restrict);

            //Owner check
            modelBuilder.Entity<GuestRating>()
                .HasOne<Owner>()
                .WithMany(t => t.GuestRatings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Accomodation>()
                .HasOne<Owner>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Restrict);

            //AccomodationReservation check
            modelBuilder.Entity<Accomodation>()
            .HasOne<AccomodationReservation>()
           .WithMany(t => t.Accomodations)
           .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<User>()
            //.HasOne<AccomodationReservation>()
            // .WithMany(t => t.Users)
            //.OnDelete(DeleteBehavior.Cascade);

            //GuestRating 
            //modelBuilder.Entity<GuestRating>()
            //.HasOne<User>();
            //.WithMany(t => t.AccomodationReservations)
            //.OnDelete(DeleteBehavior.Cascade);



        }

        public string path = @"C:\Temp\SIMSdatabase.db";
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source = {path}");

    }
}

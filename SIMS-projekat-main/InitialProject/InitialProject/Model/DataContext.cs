﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<TourReservation> TourReservations { get; set; }
        public DbSet<Dates> Dates { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<TourRating> Rating { get; set; }
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

            modelBuilder.Entity<Dates>()
                .HasOne<Tour>()
                .WithMany(t => t.StartingDates)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TourReservation>()
                .HasOne<Tour>()
                .WithMany(t => t.TourReservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TourReservation>()
                .HasOne<Checkpoint>()
                .WithMany(t => t.TourReservations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TourReservation>()
                .HasOne<Tourist>()
                .WithMany(t => t.TourReservations)
                .OnDelete(DeleteBehavior.Cascade);

            //Accomodations
            modelBuilder.Entity<AccomodationImage>()
                .HasOne<Accomodation>()
                .WithMany(t => t.Images)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccomodationReservation>()
               .HasOne<Accomodation>()
               .WithMany(t => t.AccomodationReservations)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccomodationReservation>()
               .HasOne<Guest>()
               .WithMany(t => t.AccomodationReservations)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Guest>()
               .HasOne<Accomodation>()
               .WithMany(t => t.Guests)
               .OnDelete(DeleteBehavior.Cascade);

            //Checkpoint



            //Checkpoint
            modelBuilder.Entity<Tourist>()
               .HasOne<Checkpoint>()
               .WithMany(t => t.Tourists)
               .OnDelete(DeleteBehavior.Cascade);

            //Guest
            modelBuilder.Entity<Accomodation>()
                .HasOne<Guest>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne<Guest>()
                .WithMany(t => t.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            //Guide
            modelBuilder.Entity<Tour>()
                .HasOne<Guide>()
                .WithMany(t => t.Tours)
                .OnDelete(DeleteBehavior.Cascade);

            //Lokacija

            modelBuilder.Entity<Accomodation>()
                .HasOne<Location>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tour>()
                .HasOne<Location>()
                .WithMany(t => t.Tours)
                .OnDelete(DeleteBehavior.Cascade);

            //Owner
            modelBuilder.Entity<GuestRating>()
                .HasOne<Owner>()
                .WithMany(t => t.GuestRatings)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Accomodation>()
                .HasOne<Owner>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Cascade);

            //AccomodationReservation 
            modelBuilder.Entity<Accomodation>()
            .HasOne<AccomodationReservation>()
            .WithMany(t => t.Accomodations)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
           .HasOne<AccomodationReservation>()
           .WithMany(t => t.Users)
           .OnDelete(DeleteBehavior.Cascade);

            //GuestRating 
            //modelBuilder.Entity<AccomodationReservation>()
            //.HasOne<GuestRating>()
            //.WithMany(t => t.AccomodationReservations)
            //.OnDelete(DeleteBehavior.Cascade);

            //Dates
            modelBuilder.Entity<Tourist>()
           .HasOne<Dates>()
           .WithMany(t => t.tourists)
           .OnDelete(DeleteBehavior.Cascade);


            //Coupons
            modelBuilder.Entity<Coupon>()
           .HasOne<Tourist>()
           .WithMany(t => t.Coupons)
           .OnDelete(DeleteBehavior.Cascade);

            //TourRating
            modelBuilder.Entity<TourRating>()
           .HasOne<Tourist>()
           .WithMany(t => t.Ratings)
           .OnDelete(DeleteBehavior.Cascade);
        }
        public string path = @"C:\Users\Strahinja\Desktop\SIMS_DB\database.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source = {path}");

    }
}

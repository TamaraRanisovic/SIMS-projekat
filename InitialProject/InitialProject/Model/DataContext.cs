
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

        public DbSet<TourReservation> TourReservations { get; set; }
        public DbSet<Dates> Dates { get; set; }

        public DbSet<Coupon> Coupons { get; set; }

        public DbSet<TourRating> TourRatings { get; set; }

        public DbSet<TouristNotifications> TouristNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tura
            modelBuilder.Entity<TourImages>()
                .HasOne<Tour>()
                .WithMany(t => t.Images)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Checkpoint>()
                .HasOne<Tour>()
                .WithMany(t => t.Checkpoints)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tourist>()
                .HasOne<Tour>()
                .WithMany(t => t.Tourists)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Dates>()
                .HasOne<Tour>()
                .WithMany(t => t.StartingDates)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourReservation>()
                .HasOne<Tour>()
                .WithMany(t => t.TourReservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourReservation>()
                .HasOne<Checkpoint>()
                .WithMany(t => t.TourReservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourReservation>()
                .HasOne<Tourist>()
                .WithMany(t => t.TourReservations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourRating>()
                .HasOne<Tour>()
                .WithMany(t => t.TourRatings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourRating>()
                .HasOne<Tourist>()
                .WithMany(t => t.TourRatings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourImages>()
                .HasOne<TourRating>()
                .WithMany(t => t.TourImages)
                .OnDelete(DeleteBehavior.Restrict);

            //Accomodations
            modelBuilder.Entity<AccomodationImage>()
                .HasOne<Accomodation>()
                .WithMany(t => t.Images)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccomodationReservation>()
               .HasOne<Accomodation>()
               .WithMany(t => t.AccomodationReservations)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AccomodationReservation>()
               .HasOne<Guest>()
               .WithMany(t => t.AccomodationReservations)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Guest>()
               .HasOne<Accomodation>()
               .WithMany(t => t.Guests)
               .OnDelete(DeleteBehavior.Restrict);

            //Checkpoint



            //Checkpoint
            modelBuilder.Entity<Tourist>()
               .HasOne<Checkpoint>()
               .WithMany(t => t.Tourists)
               .OnDelete(DeleteBehavior.Restrict);

            //Guest
            modelBuilder.Entity<Accomodation>()
                .HasOne<Guest>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne<Guest>()
                .WithMany(t => t.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            //Guide
            modelBuilder.Entity<Tour>()
                .HasOne<Guide>()
                .WithMany(t => t.Tours)
                .OnDelete(DeleteBehavior.Restrict);

            //Lokacija

            modelBuilder.Entity<Accomodation>()
                .HasOne<Location>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tour>()
                .HasOne<Location>()
                .WithMany(t => t.Tours)
                .OnDelete(DeleteBehavior.Restrict);

            //Owner
            modelBuilder.Entity<GuestRating>()
                .HasOne<Owner>()
                .WithMany(t => t.GuestRatings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Accomodation>()
                .HasOne<Owner>()
                .WithMany(t => t.Accomodations)
                .OnDelete(DeleteBehavior.Restrict);

            //AccomodationReservation 
            modelBuilder.Entity<Accomodation>()
            .HasOne<AccomodationReservation>()
            .WithMany(t => t.Accomodations)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
           .HasOne<AccomodationReservation>()
           .WithMany(t => t.Users)
           .OnDelete(DeleteBehavior.Restrict);

            //GuestRating 
            //modelBuilder.Entity<AccomodationReservation>()
            //.HasOne<GuestRating>()
            //.WithMany(t => t.AccomodationReservations)
            //.OnDelete(DeleteBehavior.Cascade);

            //Dates
            modelBuilder.Entity<Tourist>()
           .HasOne<Dates>()
           .WithMany(t => t.Tourists)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TouristNotifications>()
           .HasOne<Tourist>()
           .WithMany(t => t.TouristNotifications)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TouristNotifications>()
           .HasOne<TourReservation>()
           .WithMany(t => t.Notifications)
           .OnDelete(DeleteBehavior.Restrict);

            //Coupons
            modelBuilder.Entity<Coupon>()
           .HasOne<Tourist>()
           .WithMany(t => t.Coupons)
           .OnDelete(DeleteBehavior.Restrict);



        }
        public string path = @"C:\Users\Strahinja\Desktop\SIMS_DB\database.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source = {path}");

    }
}

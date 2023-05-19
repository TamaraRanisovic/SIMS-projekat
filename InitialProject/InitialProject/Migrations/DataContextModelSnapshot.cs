﻿// <auto-generated />
using System;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InitialProject.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("InitialProject.Model.Accomodation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccomodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("DaysBeforeCanceling")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastRenovation")
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MinReservationDays")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RecentlyRenovated")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationReservationId");

                    b.HasIndex("GuestId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accomodations");
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccomodationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("AccomodationImages");
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccomodationId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.HasIndex("GuestId");

                    b.HasIndex("UserId");

                    b.ToTable("AccomodationReservations");
                });

            modelBuilder.Entity("InitialProject.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("InitialProject.Model.GuestRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cleanliness")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RatingExperationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RuleCompliance")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationReservationId");

                    b.HasIndex("OwnerId");

                    b.ToTable("GuestRatings");
                });

            modelBuilder.Entity("InitialProject.Model.OwnerReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cleanliness")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("OwnerFairness")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationReservationId");

                    b.ToTable("OwnerReviews");
                });

            modelBuilder.Entity("InitialProject.Model.Renovation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationId");

                    b.ToTable("Renovations");
                });

            modelBuilder.Entity("InitialProject.Model.RenovationSuggestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RenovationRating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationReservationId");

                    b.ToTable("RenovationSuggestions");
                });

            modelBuilder.Entity("InitialProject.Model.ReservationReschedulingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Achievable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NewEndingDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("NewStartingDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.ToTable("ReservationReschedulingRequests");
                });

            modelBuilder.Entity("InitialProject.Model.TourImages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("TourImages");
                });

            modelBuilder.Entity("InitialProject.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("InitialProject.Resources.Images.AccommodationReservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Cancelled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AccommodationReservations");
                });

            modelBuilder.Entity("WebApi.Entities.Checkpoint", b =>
                {
                    b.Property<int>("CheckpointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("CheckpointId");

                    b.HasIndex("TourId");

                    b.ToTable("Checkpoints");
                });

            modelBuilder.Entity("WebApi.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApi.Entities.Tour", b =>
                {
                    b.Property<int>("TourId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuideId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("LocationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MaxGuests")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("TourId");

                    b.HasIndex("GuideId");

                    b.HasIndex("LocationId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("InitialProject.Model.Guest", b =>
                {
                    b.HasBaseType("InitialProject.Model.User");

                    b.HasDiscriminator().HasValue("Guest");
                });

            modelBuilder.Entity("InitialProject.Model.Guide", b =>
                {
                    b.HasBaseType("InitialProject.Model.User");

                    b.HasDiscriminator().HasValue("Guide");
                });

            modelBuilder.Entity("InitialProject.Model.Owner", b =>
                {
                    b.HasBaseType("InitialProject.Model.User");

                    b.Property<bool>("SuperOwner")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("InitialProject.Model.Tourist", b =>
                {
                    b.HasBaseType("InitialProject.Model.User");

                    b.Property<int?>("CheckpointId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("TourId");

                    b.HasDiscriminator().HasValue("Tourist");
                });

            modelBuilder.Entity("InitialProject.Model.Accomodation", b =>
                {
                    b.HasOne("InitialProject.Model.AccomodationReservation", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("AccomodationReservationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApi.Entities.Location", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Owner", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationImage", b =>
                {
                    b.HasOne("InitialProject.Model.Accomodation", null)
                        .WithMany("Images")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationReservation", b =>
                {
                    b.HasOne("InitialProject.Model.Accomodation", null)
                        .WithMany("AccomodationReservations")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("AccomodationReservations")
                        .HasForeignKey("GuestId");

                    b.HasOne("InitialProject.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("InitialProject.Model.Comment", b =>
                {
                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("Comments")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.GuestRating", b =>
                {
                    b.HasOne("InitialProject.Model.AccomodationReservation", "AccomodationReservation")
                        .WithMany()
                        .HasForeignKey("AccomodationReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InitialProject.Model.Owner", null)
                        .WithMany("GuestRatings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AccomodationReservation");
                });

            modelBuilder.Entity("InitialProject.Model.OwnerReview", b =>
                {
                    b.HasOne("InitialProject.Model.AccomodationReservation", "AccomodationReservation")
                        .WithMany()
                        .HasForeignKey("AccomodationReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccomodationReservation");
                });

            modelBuilder.Entity("InitialProject.Model.Renovation", b =>
                {
                    b.HasOne("InitialProject.Model.Accomodation", "Accomodation")
                        .WithMany("Renovations")
                        .HasForeignKey("AccomodationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accomodation");
                });

            modelBuilder.Entity("InitialProject.Model.RenovationSuggestion", b =>
                {
                    b.HasOne("InitialProject.Model.AccomodationReservation", "AccomodationReservation")
                        .WithMany()
                        .HasForeignKey("AccomodationReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccomodationReservation");
                });

            modelBuilder.Entity("InitialProject.Model.ReservationReschedulingRequest", b =>
                {
                    b.HasOne("InitialProject.Model.AccomodationReservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("InitialProject.Model.TourImages", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Images")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Resources.Images.AccommodationReservation", b =>
                {
                    b.HasOne("InitialProject.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApi.Entities.Checkpoint", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Checkpoints")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApi.Entities.Tour", b =>
                {
                    b.HasOne("InitialProject.Model.Guide", null)
                        .WithMany("Tours")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Location", null)
                        .WithMany("Tours")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.Tourist", b =>
                {
                    b.HasOne("WebApi.Entities.Checkpoint", null)
                        .WithMany("Tourists")
                        .HasForeignKey("CheckpointId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Tourists")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.Accomodation", b =>
                {
                    b.Navigation("AccomodationReservations");

                    b.Navigation("Images");

                    b.Navigation("Renovations");
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationReservation", b =>
                {
                    b.Navigation("Accomodations");
                });

            modelBuilder.Entity("WebApi.Entities.Checkpoint", b =>
                {
                    b.Navigation("Tourists");
                });

            modelBuilder.Entity("WebApi.Entities.Location", b =>
                {
                    b.Navigation("Accomodations");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("WebApi.Entities.Tour", b =>
                {
                    b.Navigation("Checkpoints");

                    b.Navigation("Images");

                    b.Navigation("Tourists");
                });

            modelBuilder.Entity("InitialProject.Model.Guest", b =>
                {
                    b.Navigation("AccomodationReservations");

                    b.Navigation("Accomodations");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("InitialProject.Model.Guide", b =>
                {
                    b.Navigation("Tours");
                });

            modelBuilder.Entity("InitialProject.Model.Owner", b =>
                {
                    b.Navigation("Accomodations");

                    b.Navigation("GuestRatings");
                });
#pragma warning restore 612, 618
        }
    }
}

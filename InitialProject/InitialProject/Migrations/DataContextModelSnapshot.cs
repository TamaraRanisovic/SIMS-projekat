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
                    b.Property<int>("AccId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccomodationReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccomodationType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DaysBeforeCanceling")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("GuestId")
                        .HasColumnType("INTEGER");

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

                    b.HasKey("AccId");

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

                    b.Property<int?>("AccomodationAccId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccomodationAccId");

                    b.ToTable("AccomodationImages");
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationReservation", b =>
                {
                    b.Property<int>("AccomodationReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccomodationAccId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CheckOutDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccomodationReservationId");

                    b.HasIndex("AccomodationAccId");

                    b.HasIndex("GuestId");

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

            modelBuilder.Entity("InitialProject.Model.Coupon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TouristId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TouristId");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("InitialProject.Model.Dates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("Dates");
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

            modelBuilder.Entity("InitialProject.Model.TourImage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourRatingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("TourRatingId");

                    b.ToTable("TourImages");
                });

            modelBuilder.Entity("InitialProject.Model.TouristNotification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourRequestId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourReservationId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TouristId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TourRequestId");

                    b.HasIndex("TourReservationId");

                    b.HasIndex("TouristId");

                    b.ToTable("TouristNotifications");
                });

            modelBuilder.Entity("InitialProject.Model.TourRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GuideKnowledge")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuideLanguage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsValid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TourAmusement")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TouristId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.HasIndex("TouristId");

                    b.ToTable("TourRatings");
                });

            modelBuilder.Entity("InitialProject.Model.TourRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuideId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RequestStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TouristId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tourists")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GuideId");

                    b.HasIndex("TouristId");

                    b.ToTable("TourRequests");
                });

            modelBuilder.Entity("InitialProject.Model.TourReservation", b =>
                {
                    b.Property<int>("TourReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Attendance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CheckpointId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TouristId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TouristsNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("TourReservationId");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("TourId");

                    b.HasIndex("TouristId");

                    b.ToTable("TourReservations");
                });

            modelBuilder.Entity("InitialProject.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccomodationReservationId")
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

                    b.HasIndex("AccomodationReservationId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
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

                    b.Property<int>("GuideId")
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

                    b.HasKey("TourId");

                    b.HasIndex("GuideId");

                    b.HasIndex("LocationId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("InitialProject.Model.Guest", b =>
                {
                    b.HasBaseType("InitialProject.Model.User");

                    b.Property<int?>("AccomodationAccId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AccomodationAccId");

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

                    b.HasDiscriminator().HasValue("Owner");
                });

            modelBuilder.Entity("InitialProject.Model.Tourist", b =>
                {
                    b.HasBaseType("InitialProject.Model.User");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CheckpointId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DatesId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsPresent")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TourId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("CheckpointId");

                    b.HasIndex("DatesId");

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
                        .HasForeignKey("AccomodationAccId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationReservation", b =>
                {
                    b.HasOne("InitialProject.Model.Accomodation", null)
                        .WithMany("AccomodationReservations")
                        .HasForeignKey("AccomodationAccId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("AccomodationReservations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.Comment", b =>
                {
                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("Comments")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.Coupon", b =>
                {
                    b.HasOne("InitialProject.Model.Tourist", null)
                        .WithMany("Coupons")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.Dates", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("StartingDates")
                        .HasForeignKey("TourId")
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

            modelBuilder.Entity("InitialProject.Model.TourImage", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Images")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.TourRating", null)
                        .WithMany("TourImages")
                        .HasForeignKey("TourRatingId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.TouristNotification", b =>
                {
                    b.HasOne("InitialProject.Model.TourRequest", null)
                        .WithMany("Notifications")
                        .HasForeignKey("TourRequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InitialProject.Model.TourReservation", null)
                        .WithMany("Notifications")
                        .HasForeignKey("TourReservationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Tourist", null)
                        .WithMany("TouristNotifications")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.TourRating", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("TourRatings")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Tourist", null)
                        .WithMany("TourRatings")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("InitialProject.Model.TourRequest", b =>
                {
                    b.HasOne("InitialProject.Model.Guide", null)
                        .WithMany("TourRequests")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InitialProject.Model.Tourist", null)
                        .WithMany("TourRequests")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.TourReservation", b =>
                {
                    b.HasOne("WebApi.Entities.Checkpoint", null)
                        .WithMany("TourReservations")
                        .HasForeignKey("CheckpointId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("TourReservations")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Tourist", null)
                        .WithMany("TourReservations")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.User", b =>
                {
                    b.HasOne("InitialProject.Model.AccomodationReservation", null)
                        .WithMany("Users")
                        .HasForeignKey("AccomodationReservationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApi.Entities.Checkpoint", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Checkpoints")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("WebApi.Entities.Tour", b =>
                {
                    b.HasOne("InitialProject.Model.Guide", null)
                        .WithMany("Tours")
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.Location", null)
                        .WithMany("Tours")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.Guest", b =>
                {
                    b.HasOne("InitialProject.Model.Accomodation", null)
                        .WithMany("Guests")
                        .HasForeignKey("AccomodationAccId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.Tourist", b =>
                {
                    b.HasOne("WebApi.Entities.Checkpoint", null)
                        .WithMany("Tourists")
                        .HasForeignKey("CheckpointId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("InitialProject.Model.Dates", null)
                        .WithMany("Tourists")
                        .HasForeignKey("DatesId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Tourists")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("InitialProject.Model.Accomodation", b =>
                {
                    b.Navigation("AccomodationReservations");

                    b.Navigation("Guests");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationReservation", b =>
                {
                    b.Navigation("Accomodations");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("InitialProject.Model.Dates", b =>
                {
                    b.Navigation("Tourists");
                });

            modelBuilder.Entity("InitialProject.Model.TourRating", b =>
                {
                    b.Navigation("TourImages");
                });

            modelBuilder.Entity("InitialProject.Model.TourRequest", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("InitialProject.Model.TourReservation", b =>
                {
                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("WebApi.Entities.Checkpoint", b =>
                {
                    b.Navigation("TourReservations");

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

                    b.Navigation("StartingDates");

                    b.Navigation("TourRatings");

                    b.Navigation("TourReservations");

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
                    b.Navigation("TourRequests");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("InitialProject.Model.Owner", b =>
                {
                    b.Navigation("Accomodations");

                    b.Navigation("GuestRatings");
                });

            modelBuilder.Entity("InitialProject.Model.Tourist", b =>
                {
                    b.Navigation("Coupons");

                    b.Navigation("TourRatings");

                    b.Navigation("TourRequests");

                    b.Navigation("TourReservations");

                    b.Navigation("TouristNotifications");
                });
#pragma warning restore 612, 618
        }
    }
}

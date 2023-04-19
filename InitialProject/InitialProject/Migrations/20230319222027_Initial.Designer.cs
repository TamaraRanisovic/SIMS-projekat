﻿// <auto-generated />
using System;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InitialProject.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230319222027_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("InitialProject.Model.Accomodation", b =>
                {
                    b.Property<int>("AccId")
                        .ValueGeneratedOnAdd()
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

                    b.Property<int>("Cleanliness")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("RatingExperationDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RuleCompliance")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("GuestRatings");
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
                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApi.Entities.Location", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InitialProject.Model.Owner", null)
                        .WithMany("Accomodations")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.AccomodationImage", b =>
                {
                    b.HasOne("InitialProject.Model.Accomodation", null)
                        .WithMany("Images")
                        .HasForeignKey("AccomodationAccId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.Comment", b =>
                {
                    b.HasOne("InitialProject.Model.Guest", null)
                        .WithMany("Comments")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.GuestRating", b =>
                {
                    b.HasOne("InitialProject.Model.Owner", null)
                        .WithMany("GuestRatings")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InitialProject.Model.TourImages", b =>
                {
                    b.HasOne("WebApi.Entities.Tour", null)
                        .WithMany("Images")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.Navigation("Images");
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

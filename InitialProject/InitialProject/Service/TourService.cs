using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class TourService
    {

        public LocationRepository locationRepository = new LocationRepository();
        public TourRepository tourRepository = new TourRepository();
       
        public TourService() { }


        public void MakeTour(Tour tour, Location location, List<TourImages> tourImages, List<Checkpoint> checkpoints)
        {       

            using (var context = new DataContext())
            {
                
                Location existingLocation = locationRepository.GetLocationByCityAndCountry(location.City, location.Country);
                
                

                if (existingLocation != null)
                {
                    location = existingLocation;
                    location.Tours.Add(tour);
                    context.Locations.Update(location);
                }
                else
                {
                    location.Tours.Add(tour);
                    context.Locations.Add(location);
                }

                foreach (var image in tourImages)
                {
                    context.TourImages.Add(image);
                    tour.Images.Add(image);
                }

                foreach (var checkpoint in checkpoints)
                {
                    context.Checkpoints.Add(checkpoint);
                    tour.Checkpoints.Add(checkpoint);
                }

                

                context.SaveChanges();
            }
        }

        public void TourTracking()
        {
            
            using (var context = new DataContext())
            {
                TourRepository tourRepository = new TourRepository();
                List<Tour> todaysTours = tourRepository.GetToursList();

                foreach (var tour in todaysTours)
                {
                    foreach (var tourist in tour.Tourists)
                    {
                        Console.WriteLine("CheckpointId: " + tourist.Password);
                        Console.WriteLine("CheckpointName: " + tourist.Username);
                        Console.WriteLine("-------------------------");
                    }
                }

                string trackingTourName = FindTodaysToursName();

                Tour trackingTour = new Tour();

                trackingTour = startTrackingTour(trackingTourName, todaysTours, trackingTour);
                context.SaveChanges();
                ShowCheckpoints(trackingTour);

                Menu(trackingTour);


                context.SaveChanges();
            }

        }

        private static void WriteMenuOptions()
        {
            Console.WriteLine("1.Oznaci Cekpoint\n");
            Console.WriteLine("2.Oznaci prisutne turiste\n");
            Console.WriteLine("3.Zavrsi turu\n");
            Console.WriteLine("x. exit");
            Console.Write("Your option: ");
        }

        private void ProcessChosenOption(string chosenOption, Tour trackingTour)
        {
            Checkpoint currentCheckpoint = new Checkpoint();
            currentCheckpoint = FindStartCheckpoint(trackingTour);

            switch (chosenOption)
            {
                case "1":
                    Console.WriteLine("Izabrali ste oznacavanje Cekpointa");
                    currentCheckpoint = MarkingCheckpoints(trackingTour);
                    break;
                case "2":
                    Console.WriteLine("Izabrali ste da oznacite prisutne");
                    MarkingPresentTourists(currentCheckpoint, trackingTour);
                    break;
                case "3":
                    Console.WriteLine("Izabrali ste da zavrsite turu");
                    break;
                case "x":
                    break;
                default:
                    Console.WriteLine("Option does not exist");
                    break;
            }

        }

        public string FindTodaysToursName()
        { 
           // Console.Clear();
            Console.WriteLine("Unesite ime ture koju zelite da zapocnete: ");
            string trackingTourName = Console.ReadLine();

            return trackingTourName;
        }

        public Tour startTrackingTour(string trackingTourName, List<Tour>todaysTours, Tour trackingTour)
        {

            using (var context = new DataContext())
            {
                foreach (var tour in todaysTours)
                {
                    if (tour.Name == trackingTourName)
                    {
                        trackingTour = tour;
                        break;
                    }
                }

                // Pronađi prvi checkpoint sa statusom false i ažuriraj ga
                foreach(var checkpoint in trackingTour.Checkpoints)
                {
                    if(checkpoint.Type == 0)
                    {
                        checkpoint.Status = true;
                        context.Checkpoints.Update(checkpoint);
                        context.SaveChanges();
                    }
                }
                
            }

            Console.WriteLine($"Tura {trackingTour.Name} je zapoceta");
            Console.WriteLine("-------------------------");

            return trackingTour;
        }

        public void ShowCheckpoints(Tour trackingTour)
        {
            foreach (var checkpoint in trackingTour.Checkpoints)
            {

                Console.WriteLine("CheckpointId: " + checkpoint.CheckpointId);
                Console.WriteLine("CheckpointName: " + checkpoint.Name);
                Console.WriteLine("CheckpointType: " + checkpoint.Type);
                Console.WriteLine("CheckpointStatus: " + checkpoint.Status + "\n");
                Console.WriteLine("-------------------------");
            }
        }

        public void Menu(Tour trackingTour)
        {
            string chosenOption;
            Console.WriteLine("Meni za dalje instrukcije: ");
            Console.WriteLine("-------------------------");
            do
            {
                WriteMenuOptions();
                chosenOption = Console.ReadLine();
                Console.WriteLine("-------------------------");
                Console.Clear();
                ProcessChosenOption(chosenOption, trackingTour);
            } while (!chosenOption.Equals("x"));

        }

        public void ShowCheckpointsList(List<Checkpoint> checkpoints)
        {
            foreach (var checkpoint in checkpoints)
            {

                Console.WriteLine("CheckpointId: " + checkpoint.CheckpointId);
                Console.WriteLine("CheckpointName: " + checkpoint.Name);
                Console.WriteLine("CheckpointType: " + checkpoint.Type);
                Console.WriteLine("CheckpointStatus: " + checkpoint.Status + "\n");
                Console.WriteLine("-------------------------");
            }
        }

        public Checkpoint MarkingCheckpoints(Tour trackingTour)
        {
           
            List<Checkpoint> falseCheckpoints = new List<Checkpoint>();
            foreach(var  checkpoint in trackingTour.Checkpoints)
            {
                if (!checkpoint.Status)
                {
                    falseCheckpoints.Add(checkpoint);
                }   
            }

            

            Console.Clear();
            Console.WriteLine("----------------------------");
            Console.WriteLine("Lista neoznacenih cekpointa:\n\n");
            Console.WriteLine("----------------------------");
            ShowCheckpointsList(falseCheckpoints);

            Console.WriteLine("Unesite ime cekpointa koji zelite da oznacite:\n\n");
            string name = Console.ReadLine();

            MarkCheckpoint(FindCheckpointForMarking(falseCheckpoints, name), trackingTour);

            return FindCheckpointForMarking(falseCheckpoints, name);
        }

        public void MarkCheckpoint(Checkpoint checkpoint, Tour trackingTour)
        {
            using(var db = new DataContext()) {
                foreach (var checkPoint in trackingTour.Checkpoints)
                {
                    if (checkPoint.CheckpointId == checkpoint.CheckpointId)
                    {

                        checkpoint.Status = true;
                        db.Checkpoints.Update(checkpoint);
                        db.SaveChanges();
                    }
                }
                
            }

        }

        public Checkpoint FindCheckpointForMarking(List<Checkpoint> checkpoints, string name)
        {
            foreach(var checkpoint in checkpoints)
            {
                if(checkpoint.Name == name)
                {
                    return checkpoint;
                }
            }
            return null;
        }

        public Checkpoint FindStartCheckpoint(Tour tour)
        {
            foreach (var checkpoint in tour.Checkpoints)
            {
                if(checkpoint.Type == CheckpointType.Start)
                {
                    return checkpoint;
                }
            }
            return null;
        }
        public void MarkingPresentTourists(Checkpoint currentCheckpoint, Tour trackingTour)
        {
            Console.WriteLine("TEST"); //ne ucitava turiste ili ne prepoznaje
            
            foreach(var tourist in trackingTour.Tourists)
            {
                Console.WriteLine("Ime turiste: " + tourist.Username);
                Console.WriteLine("da li je turista prisutan" + tourist.IsPresent);
            }

        }
    }
        
}

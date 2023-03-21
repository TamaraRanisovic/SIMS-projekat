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
                //1 ucitaj danasnje ture public List<Tour> todaysTours()
                TourRepository tourRepository = new TourRepository();
                List<Tour> todaysTours = tourRepository.GetToursList();

               /* foreach (var tour in todaysTours)
                {
                    foreach(var checkpoint in tour.Checkpoints)
                    {
                        Console.WriteLine(checkpoint.Name);
                    }
                }*/

                //2 pronadji turu koju zelis da zapocnes public Tour StartTour()
                Console.Clear();
                Console.WriteLine("Unesite ime ture koju zelite da zapocnete: ");
                string trackingTourName = Console.ReadLine();

                Tour trackingTour = new Tour();

                foreach (var tour in todaysTours)
                {
                    if (tour.Name == trackingTourName)
                    {
                        trackingTour = tour;
                    }
                }
                foreach(var checkpoint in trackingTour.Checkpoints)
                {
                    if(checkpoint.Type == 0)
                    {
                        checkpoint.Status = true;
                    }
                }
                Console.WriteLine($"Tura {trackingTour.Name} je zapoceta");
                Console.WriteLine("-------------------------");

                //3 izlistaj checkpointe ture
                foreach (var checkpoint in trackingTour.Checkpoints)
                {
                   
                    Console.WriteLine("CheckpointId: " + checkpoint.CheckpointId);
                    Console.WriteLine("CheckpointName: " + checkpoint.Name);
                    Console.WriteLine("CheckpointType: " + checkpoint.Type);
                    Console.WriteLine("CheckpointStatus: " + checkpoint.Status + "\n");
                    Console.WriteLine("-------------------------");
                }

                //4 pravimo meni sa opcijama za dalji 

                string chosenOption;
                Console.WriteLine("Meni za dalje instrukcije: ");
                Console.WriteLine("-------------------------");
                do
                {
                    WriteMenuOptions();                  
                    chosenOption = Console.ReadLine();
                    Console.WriteLine("-------------------------");
                    Console.Clear();
                    ProcessChosenOption(chosenOption);
                } while (!chosenOption.Equals("x"));

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

        private static void ProcessChosenOption(string chosenOption)
        {

            switch (chosenOption)
            {
                case "1":
                    Console.WriteLine("Izabrali ste oznacavanje Cekpointa");
                    break;
                case "2":
                    Console.WriteLine("Izabrali ste da oznacite prisutne");
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

    }
        
}

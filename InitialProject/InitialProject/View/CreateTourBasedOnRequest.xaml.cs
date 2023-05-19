using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebApi.Entities;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for CreateTourBasedOnRequest.xaml
    /// </summary>
    public partial class CreateTourBasedOnRequest : Window
    {   
        public TourRequest TourRequest { get; set; }
        public List<Checkpoint> checkpoints { get; set; }

        public LocationRepository locationRepository = new LocationRepository();
        public TourService tourService = new TourService(new TourRepository());

        public CreateTourBasedOnRequest()
        {
            InitializeComponent();
            checkpoints = new List<Checkpoint>();
        }

        public CreateTourBasedOnRequest(TourRequest tourRequest)
        {
            InitializeComponent();
            TourRequest = tourRequest;
            checkpoints = new List<Checkpoint>();
        }

        private void CreateTour(object sender, RoutedEventArgs e)
        {
            Location location = locationRepository.GetByCityAndCountry(TourRequest.City, TourRequest.Country);
            if (location != null)
            { 

                Tour tour = new Tour(Name.Text, TourRequest.Description, TourRequest.Language, int.Parse(NumOfGuests.Text), int.Parse(Duration.Text));
                Dates date = new Dates(DateTime.Parse(Date.Text));
                TourImage tourImages = new TourImage(Image.Text);

                TourCreate(date, tourImages, tour, location);
            }
            else
            {
                Location newLocation = new Location(TourRequest.City, TourRequest.Country);
                locationRepository.Add(newLocation);

                Tour tour = new Tour(Name.Text, TourRequest.Description, TourRequest.Language, int.Parse(NumOfGuests.Text), int.Parse(Duration.Text));
                Dates date = new Dates(DateTime.Parse(Date.Text));
                TourImage tourImages = new TourImage(Image.Text);

                TourCreate(date, tourImages, tour, newLocation);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   

            CheckpointType Type = (CheckpointType)Enum.Parse(typeof(CheckpointType), CheckpointType.Text);
            Checkpoint checkpoint = new Checkpoint(CheckpointName.Text, Type);
            checkpoints.Add(checkpoint);
            Data.ItemsSource = null;
            Data.ItemsSource = checkpoints;
            MessageBox.Show("Uspesno dodat Checkpint");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Checkpoint checkpoint = Data.SelectedItem as Checkpoint;
            List<Checkpoint> checkpointsToRemove = new List<Checkpoint>();

            foreach (var t in checkpoints)
            {
                if(t.Name.Equals(checkpoint.Name))
                {
                    checkpointsToRemove.Add(t);
                }
            }

            foreach(var t in checkpointsToRemove)
            {
                checkpoints.Remove(t);
            }
            Data.ItemsSource = null;
            Data.ItemsSource = checkpoints;
        }

        public void TourCreate(Dates date, TourImage tourImages, Tour tour, Location location)
        {
            if (date.Date < TourRequest.StartDate || date.Date > TourRequest.EndDate)
            {
                MessageBox.Show("Datum nije u opsegu");
                Date.Text = "";
            }
            else
            {

                List<Dates> dates = new List<Dates>();
                List<TourImage> images = new List<TourImage>();

                dates.Add(date);
                images.Add(tourImages);
                tour.GuideId = UserSession.LoggedInUser.Id;
                tourService.MakeTour(tour, location, images, checkpoints, dates);
            }
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow();
            guideWindow.Show();
            Close();
        }
    }
}

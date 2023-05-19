using InitialProject.DTO;
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

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for Review.xaml
    /// </summary>
    public partial class ReviewView : Window
    {   
        public int DateId { get; set; }
        ReviewService reviewService = new ReviewService();
        public ReviewView(int dateId)
        {
            InitializeComponent();
            DateId = dateId;
        }

        private void ShowTour_Click(object sender, RoutedEventArgs e)
        {
            

            List<TourRatingCheckpointDTO> list = reviewService.ShowReview(DateId);
            ListOfTours.ItemsSource = list;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   

            var selectedItem = ListOfTours.SelectedItem as TourRatingCheckpointDTO;

            reviewService.UnvalidRating(selectedItem);
            List<TourRatingCheckpointDTO> list = reviewService.ShowReview(DateId);
            ListOfTours.ItemsSource = list;
        }
    }
}

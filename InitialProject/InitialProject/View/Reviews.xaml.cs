using InitialProject.Model;
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
    /// Interaction logic for Reviews.xaml
    /// </summary>
    public partial class Reviews : Window
    {
        public Reviews()
        {
            InitializeComponent();
        }

        private List<Review> reviews = new List<Review>();

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home();
            homeWindow.Show();
            Close();
        }

        private void ReviewGuestButton_Click(object sender, RoutedEventArgs e)
        {
            ReviewGuest reviewGuestWindow = new ReviewGuest();
            reviewGuestWindow.Show();
            Close();
        }

        private void ShowReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowGuestReviews reviewsWindow = new ShowGuestReviews(reviews);
            reviewsWindow.Show();
            Close();
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {
            Notifications notificationsWindow = new Notifications();
            notificationsWindow.Show();
            Close();
        }

        private void ShowOwnerReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            ReviewsWindow ownerReviewsWindow = new ReviewsWindow();
            ownerReviewsWindow.Show();
            Close();
        }

        private void StatusButton_Click(Object sender, RoutedEventArgs e) 
        { 
            Status statusWindow = new Status();
            statusWindow.Show();
            Close();
        }
    }
}
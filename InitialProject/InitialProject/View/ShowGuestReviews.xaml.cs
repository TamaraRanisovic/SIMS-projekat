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
    /// Interaction logic for ShowGuestReviews.xaml
    /// </summary>
    public partial class ShowGuestReviews : Window
    {
        private List<Review> reviews;
        public ShowGuestReviews(List<Review> reviews)
        {
            InitializeComponent();
            this.reviews = reviews;

            ReviewsDataGrid.Items.Clear();
            ReviewsDataGrid.ItemsSource = reviews;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Reviews reviewsWindow = new Reviews();
            reviewsWindow.Show();
            Close();
        }
    }
}

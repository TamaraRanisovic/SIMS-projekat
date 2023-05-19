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
    /// Interaction logic for ReviewGuest.xaml
    /// </summary>
    public partial class ReviewGuest : Window
    {
        private List<Review> reviews = new List<Review>();
        public ReviewGuest()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Reviews reviewsWindow = new Reviews();
            reviewsWindow.Show();
            Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Review object with the entered values

            int RuleCompliance = int.Parse(txtRuleCompliance.Text);
            int Cleanliness = int.Parse(txtCleanliness.Text);
            string Comment = txtComment.Text;
            Review review = new Review(RuleCompliance, Cleanliness, Comment);

            // Add the review to the reviews list
            reviews.Add(review);


            // Show a message box indicating successful submission
            MessageBox.Show("Review submitted successfully.");

            ShowGuestReviews reviewsDataGridWindow = new ShowGuestReviews(reviews);
            reviewsDataGridWindow.Show();

            // Clear the input fields
            txtRuleCompliance.Text = "";
            txtCleanliness.Text = "";
            txtComment.Text = "";


        }
    }
}

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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void AccommodationsButton_Click(object sender, RoutedEventArgs e)
        {
            MyAccomodations myAccomodationsWindow = new MyAccomodations();
            myAccomodationsWindow.Show();
            Close();
        }

        private void ReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            Reviews myReviewsWindow = new Reviews();
            myReviewsWindow.Show();
            Close();
        }

        private void RenovationsButton_Click(object sender, RoutedEventArgs e)
        {
            Renovations renovationsWindow = new Renovations();
            renovationsWindow.Show();
            Close();
        }

        private void ForumButton_Click(object sender, RoutedEventArgs e)
        {
            Forum forumWindow = new Forum();
            forumWindow.Show();
            Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {   
                Login loginWindow = new Login();
                loginWindow.Show();
                Close(); 
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settingsWindow = new Settings();
            settingsWindow.Show();
            Close();
        }

    }
}

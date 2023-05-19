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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for Renovations.xaml
    /// </summary>
    public partial class Renovations : Window
    {
        public Renovations()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home();
            homeWindow.Show();
            Close();
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            RenovationTest scheduleRenovationWindow = new RenovationTest();
            scheduleRenovationWindow.Show();
            Close();
        }

        private void ShowCancelButton_Click(object sender, RoutedEventArgs e)
        {
            ShowRenovationsCancel showRenovationWindow = new ShowRenovationsCancel();
            showRenovationWindow.Show();
            Close();
        }
    }
}

using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
    /// Interaction logic for ShowRenovationsCancel.xaml
    /// </summary>
    public partial class ShowRenovationsCancel : Window
    {

        RenovationService renovationsService = new RenovationService();
        public ShowRenovationsCancel()
        {
            InitializeComponent();

            List<RenovationDto> renovations = new List<RenovationDto>();

            foreach (var renovation in renovationsService.GetAll())
            {
                renovations.Add(new RenovationDto(renovation));

            }

            renovationsGrid.ItemsSource = renovations;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RenovationDto selectedRenovation = renovationsGrid.SelectedItem as RenovationDto;

            if (selectedRenovation == null)
            {

                MessageBox.Show("Please select a renovation you want to cancel.");
            }
            
            if (renovationsService.Delete(selectedRenovation)){

                MessageBox.Show("Renovation is cancelled.");
            }
            else
            {

                MessageBox.Show("Less than 5 days left before this renovation starts.\n Unable to cancell renovation.\n");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Renovations renovationsWindow = new Renovations();
            renovationsWindow.Show();
            Close();
        }
    }
}

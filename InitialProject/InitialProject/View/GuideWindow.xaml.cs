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
    public partial class GuideWindow : Window
    {
        public GuideWindow()
        {
            InitializeComponent();
        }

        private void K2_F1_Click(object sender, RoutedEventArgs e)
        {
            AcceptTourRequest acceptTourRequest = new AcceptTourRequest();
            acceptTourRequest.Show();
            Close();
        }

        private void K2_F2_Click(object sender, RoutedEventArgs e)
        {
            TourRequestStat tourRequestStat = new TourRequestStat();
            tourRequestStat.Show();
            Close();
        }

        private void K2_F3_CLick(object sender, RoutedEventArgs e)
        {
            TourProposal tourProposal = new TourProposal();
            tourProposal.Show();
            Close();
        }
    }
}

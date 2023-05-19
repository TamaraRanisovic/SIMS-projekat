using InitialProject.ViewModel;
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
<<<<<<<< HEAD:InitialProject/InitialProject/View/TouristNotificationsWindow.xaml.cs
    public partial class TouristNotificationsWindow : Page
========
    /// <summary>
    /// Interaction logic for ReccommendationRenovationWindow.xaml
    /// </summary>
    public partial class ReccommendationRenovationWindow : Window
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/ReccommendationRenovationWindow.xaml.cs
    {
        public ReccommendationRenovationWindow()
        {
            InitializeComponent();
<<<<<<<< HEAD:InitialProject/InitialProject/View/TouristNotificationsWindow.xaml.cs
          //  TouristNotificationsViewModel viewModel = new TouristNotificationsViewModel();
          //  viewModel.CloseAction = Close;
           // DataContext = viewModel;
========
            ReccommendationRenovationViewModel viewModel = new ReccommendationRenovationViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/ReccommendationRenovationWindow.xaml.cs
        }

    }
}

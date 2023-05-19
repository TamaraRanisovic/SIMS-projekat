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
<<<<<<<< HEAD:InitialProject/InitialProject/View/TourRatingWindow.xaml.cs
    public partial class TourRatingWindow : Page
========
    /// <summary>
    /// Interaction logic for RatingForYou.xaml
    /// </summary>
    public partial class RatingForYou : Window
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/RatingForYou.xaml.cs
    {
        public RatingForYou()
        {
            InitializeComponent();
<<<<<<<< HEAD:InitialProject/InitialProject/View/TourRatingWindow.xaml.cs
            TourRatingViewModel viewModel = new TourRatingViewModel();
            /*viewModel.CloseAction = Close;
            DataContext = viewModel;*/
========
            RatingForYouViewModel viewModel = new RatingForYouViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/RatingForYou.xaml.cs
        }
    }
}

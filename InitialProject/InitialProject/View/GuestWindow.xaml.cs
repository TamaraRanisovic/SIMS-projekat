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
<<<<<<<< HEAD:InitialProject/InitialProject/View/TourAttendanceWindow.xaml.cs
    public partial class TourAttendanceWindow : Page
========
    /// <summary>
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/GuestWindow.xaml.cs
    {
        public GuestWindow()
        {
            InitializeComponent();
<<<<<<<< HEAD:InitialProject/InitialProject/View/TourAttendanceWindow.xaml.cs
            /*TourAttendanceViewModel viewModel = new TourAttendanceViewModel();
========
            GuestViewModel viewModel = new GuestViewModel();
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/GuestWindow.xaml.cs
            viewModel.CloseAction = Close;
            DataContext = viewModel;*/
        }
    }
}

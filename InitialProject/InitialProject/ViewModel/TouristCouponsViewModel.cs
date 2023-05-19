using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class TouristCouponsViewModel : BindableBase
    {

         public ICommand RefreshCommand { get; set; }

         public TouristCouponsViewModel()
         {
             LoadCoupons();
             RefreshCommand = new DelegateCommand(LoadCoupons);
         }


         private ObservableCollection<Coupon> _coupons;

         public ObservableCollection<Coupon> Coupons
         {
             get { return _coupons; }
             set
             {
                 _coupons = value;
                 RaisePropertyChanged(nameof(Coupons));
             }
         }

         public void LoadCoupons()
         {
            if (UserSession.LoggedInUser != null)
            {
                TouristService touristsService = new TouristService(new TouristRepository());
                Coupons = new ObservableCollection<Coupon>(touristsService.GetTouristCoupons(UserSession.LoggedInUser.Id));
            }
            return;
        }    
    }
}

using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace InitialProject.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private RegisterDTO _registerDTO;
        private bool _isAgeEnabled;
        

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand RegisterCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public RegisterViewModel()
        {
            UserTypes = new ObservableCollection<UserType>(Enum.GetValues(typeof(UserType)).Cast<UserType>());
            RegisterCommand = new DelegateCommand(Register, CanRegister);
            CancelCommand = new DelegateCommand(Cancel);
            RegisterDTO = new RegisterDTO();
        }
        public ObservableCollection<UserType> UserTypes { get; private set; }

        public RegisterDTO RegisterDTO
        {
            get { return _registerDTO; }
            set
            {
                _registerDTO = value;
                RaisePropertyChanged(nameof(RegisterDTO));
            }
        }
        public bool IsAgeEnabled
        {
            get { return _isAgeEnabled; }
            set
            {
                _isAgeEnabled = value;
                RaisePropertyChanged(nameof(IsAgeEnabled));
            }
        }

        private bool CanRegister()
        {
            if (!string.IsNullOrEmpty(RegisterDTO.Username) &&
                !string.IsNullOrEmpty(RegisterDTO.Password) &&
                !string.IsNullOrEmpty(RegisterDTO.ConfirmPassword) &&
                RegisterDTO.Password == RegisterDTO.ConfirmPassword) {
                if (RegisterDTO.UserType == UserType.Tourist)
                {
                    IsAgeEnabled = true;
                    if (RegisterDTO.Age != 0)
                    {
                        return true;
                    }
                    return false;
                } else
                {
                    IsAgeEnabled = false;
                }
                return true;
            }
            return false;
        }

        public void ShowUserWindow()
        {
            if (RegisterDTO.UserType == UserType.Owner)
            {
                var ownerWindow = new OwnerWindow();
                ownerWindow.ShowDialog();
            }
            else if (RegisterDTO.UserType == UserType.Guide)
            {
                var guideWindow = new GuideWindow();
                guideWindow.ShowDialog();
            }
            else if (RegisterDTO.UserType == UserType.Guest)
            {
                var guestWindow = new GuestWindow();
                guestWindow.ShowDialog();
            }
            else if (RegisterDTO.UserType == UserType.Tourist)
            {
                var touristWindow = new TouristWindow();
                touristWindow.ShowDialog();
            }
        }
        private void Register()
        {          
            User user = new User(RegisterDTO.Username, RegisterDTO.Password, RegisterDTO.UserType);
            UserService userService = new UserService(new UserRepository());
            if (RegisterDTO.UserType == UserType.Tourist) {
                userService.Add(user, RegisterDTO.Age);
            }
            else {
                userService.Add(user);
            }

            ShowUserWindow();
        }

        private void Cancel()
        {
            CloseAction();
        }


        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
   
}

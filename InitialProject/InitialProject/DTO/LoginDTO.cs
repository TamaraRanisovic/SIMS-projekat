using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class LoginDTO : INotifyPropertyChanged
    {
        private string username;
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;

        public LoginDTO()
        {
            
        }

        public string Username
        {
            get { return username; }
            set { username = value; RaisePropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

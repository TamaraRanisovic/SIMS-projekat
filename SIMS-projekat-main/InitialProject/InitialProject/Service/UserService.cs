using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class UserService
    {

        UserRepository userRepository = new UserRepository();

        public UserService()
        {
            
        }

        public User Login(string username, string password)
        {
            return userRepository.Login(username, password);
        }

        public User GetByUsername(string username)
        {
            return userRepository.GetByUsername(username);
        }
    }
}

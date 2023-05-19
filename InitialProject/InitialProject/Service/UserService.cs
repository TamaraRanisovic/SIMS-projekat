using InitialProject.Interfaces;
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

        private readonly IUserRepository UserRepository;

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        
        public bool Add(User user, int touristAge = 0)
        {
            return UserRepository.Add(user, touristAge);
        }

        public User Login(string username, string password)
        {
            return UserRepository.Login(username, password);
        }
        public void UpdateStatus(bool titleFlag)
        {
            UserRepository.UpdateStatus(titleFlag);        
        }

        public User GetByUsername(string username)
        {
            return UserRepository.GetByUsername(username);
        }

        public List<Guide> GetAllGuides()
        {
            return UserRepository.GetAllGuides();
        }
    }
}

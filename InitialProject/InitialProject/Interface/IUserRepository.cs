using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Interfaces
{
    public interface IUserRepository
    {
        public bool Add(User user, int touristAge = 0);
        public List<User> GetAll();
        public User GetByUsername(string username);
        public User Login(string username, string password);
        public void Update(User updatedUser);
        public void Delete(int userId);
        public List<Guide> GetAllGuides();
        public void UpdateStatus(bool titleFlag);

    }
}

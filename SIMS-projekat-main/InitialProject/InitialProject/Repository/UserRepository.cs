using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class UserRepository
    {

        public UserRepository()
        {

        }

        public static void AddUser(User user)
        {
            using (var db = new DataContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public static List<User> GetAllUsers()
        {
            using (var db = new DataContext())
            {
                return db.Users.ToList();
            }
        }

        public User GetByUsername(string username)
        {
            using (var db = new DataContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Username.Equals(username))
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public User Login(string username, string password)
        {
            using (var db = new DataContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Username.Equals(username) && user.Password.Equals(password))
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public void UpdateUser(User updatedUser)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(t => t.Id == updatedUser.Id);
                if (user != null)
                {
                    user.Username = updatedUser.Username;
                    user.Password = updatedUser.Password;
                    user.UserType = updatedUser.UserType;
                    db.SaveChanges();
                }
            }
        }

        public void DeleteUser(int userId)
        {
            using (var db = new DataContext())
            {
                var user = db.Users.FirstOrDefault(t => t.Id == userId);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }

    }
}

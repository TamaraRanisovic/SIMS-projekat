using InitialProject.Interfaces;
using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {

        }

        public bool Add(User user, int touristAge = 0)
        {
            using (var db = new DataContext())
            {
                if (user.UserType == UserType.Owner)
                {
                    Owner owner = new Owner(user.Username, user.Password, user.UserType);
                    db.Users.Add(owner);
                }
                else if (user.UserType == UserType.Guest)
                {
                    Guest guest = new Guest(user.Username, user.Password, user.UserType);
                    db.Users.Add(guest);
                }
                else if (user.UserType == UserType.Guide)
                {
                    Guide guide = new Guide(user.Username, user.Password, user.UserType);
                    db.Users.Add(guide);
                }
                else if (user.UserType == UserType.Tourist)
                {
                    Tourist tourist = new Tourist(user.Username, user.Password, touristAge, user.UserType);
                    db.Users.Add(tourist);
                }
                db.SaveChanges();
                return true;
            }
        }

        public List<User> GetAll()
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
                    if (user.Username == username)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public void Update(User updatedUser)
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
        public void UpdateStatus(bool titleFlag) // nije radjeno za ulogovanog korisnika, naknadno ce biti ubaceno
        {

            using var db = new DataContext();
            foreach (Owner owner in db.Users)
            {
                if (owner.Username.Equals("owner"))
                {
                    owner.SuperOwner = titleFlag;
                    db.SaveChanges();
                }
            }
        }
        public void Delete(int userId)
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

        public List<Guide> GetAllGuides()
        {
            using (var db = new DataContext())
            {
                return db.Guides.Include(t => t.TourRequests).Include(t => t.Tours).ToList();
            }
        }
        public User Login(string username, string password)
        {
            using (var db = new DataContext())
            {
                foreach (User user in db.Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

    }
}

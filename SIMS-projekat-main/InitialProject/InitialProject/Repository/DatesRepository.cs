using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Repository
{
    public class DatesRepository
    {
        public DatesRepository() { }   

        public void Delete(Dates date)
        {
            using(var db = new DataContext())
            {
                 db.Dates.Remove(date);
                 db.SaveChanges();
            }
        }
         
        public List<Dates> GetAll ()
        {
            using (var db = new DataContext())
            {
                return db.Dates.Include(t=>t.tours).ToList();
            }
        }
        
        public Dates GetById(int id)
        {
            using (var db = new DataContext())
            {
                return db.Dates.FirstOrDefault(t => t.Id == id);
            }
        }
    }
}

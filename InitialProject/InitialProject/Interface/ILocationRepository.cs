using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Interfaces
{
    public interface ILocationRepository
    {
        public void Add(Location locationToAdd);
        public List<Location> GetAll();
        public void Delete(int id);
        public void Update(int id, Location locationToUpdate);
        public Location GetById(int id);
        public Location GetByCityAndCountry(string city, string country);

    }
}

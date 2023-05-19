using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Interfaces
{
    public interface ICheckpointRepository
    {
        public List<Checkpoint> GetAll();
        public Checkpoint GetById(int id);
        public List<Checkpoint> GetByTour(int tourId);


    }
}

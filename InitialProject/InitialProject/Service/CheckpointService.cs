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
    public class CheckpointService
    {
        private readonly ICheckpointRepository CheckpointRepository;

        public CheckpointService(ICheckpointRepository checkpointRepository)
        {
            CheckpointRepository = checkpointRepository;
        }
        public List<Checkpoint> GetAll()
        {
            return CheckpointRepository.GetAll();
        }

        public List<Checkpoint> GetByTour(int tourId)
        {
            return CheckpointRepository.GetByTour(tourId);
        }
    }

}

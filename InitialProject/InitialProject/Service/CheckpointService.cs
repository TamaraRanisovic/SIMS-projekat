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
        private readonly CheckpointRepository CheckpointRepository;
        public CheckpointService() { }

        public CheckpointService(CheckpointRepository checkpointRepository)
        {
            CheckpointRepository = checkpointRepository;
        }
        public List<Checkpoint> GetAllCheckpoints()
        {
            CheckpointRepository checkpointRepository = new CheckpointRepository();
            return checkpointRepository.GetAllCheckpoints();
        }

        public List<Checkpoint> GetTourCheckpoints(int tourId)
        {
            CheckpointRepository checkpointRepository = new CheckpointRepository();
            return checkpointRepository.GetTourCheckpoints(tourId);
        }
    }

}

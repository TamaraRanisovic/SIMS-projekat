using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class TourImagesRepository
    {

        public TourImagesRepository() { }

        public TourImages GetImageById(int id)
        {
            using (var db = new DataContext())
            {
                return db.TourImages.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
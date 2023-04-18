using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.Service
{
    public class AccomodationService
    {
        public AccomodationService()
        {

        }

        AccomodationRepository accomodationRepository = new AccomodationRepository();
        LocationRepository locationRepository = new LocationRepository();

        public void RegisterAccomodation(Accomodation accomodation, Location location, List<AccomodationImage> accomodationImages)
        {
            using (var context = new DataContext())
            {
                Location existingLocation = locationRepository.GetLocationByCityAndCountry(location.City, location.Country);

                if (existingLocation != null)
                {
                    location = existingLocation;
                    location.Accomodations.Add(accomodation);
                    context.Locations.Update(location);
                }
                else
                {
                    location.Accomodations.Add(accomodation);
                    context.Locations.Add(location);
                }

                foreach (var image in accomodationImages)
                {
                    context.AccomodationImages.Add(image);
                    accomodation.Images.Add(image);
                }
                context.SaveChanges();

            }

        }

        public void UpdateClassBy(bool superOwner)
        {
            string accomodationClass = "B";

            if(superOwner)
            {
                accomodationClass = "A";
            }

            this.accomodationRepository.UpdateClassBy(accomodationClass);
        }

    }
}

using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class RenovationService
    {
        public RenovationRepository renovationRepository = new RenovationRepository();
        


        public void Save(Accomodation accomodation, DateSuggestion chosenDate, string description, TimeSpan duration)
        {
            Renovation renovation = new Renovation(accomodation, chosenDate.Start, chosenDate.End, duration, description); 
            renovationRepository.Save(renovation);
        }

        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();
        }

        public bool Delete(RenovationDto renovation)
        {
            Renovation erasureRenovation = new Renovation(renovation);



            if (renovation.Start > DateTime.UtcNow.Add(new TimeSpan(5, 0, 0, 0)))
            {
                //renoviranje se moze otkazati
                this.renovationRepository.Delete(erasureRenovation);

                return true;
            }
            //preostalo je manje od 5 dana do pocetka renoviranja
            return false;

        }
    } 
}

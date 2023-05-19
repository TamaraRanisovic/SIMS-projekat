using InitialProject.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Repository
{
    public class RenovationSuggestionRepository
    {
        public RenovationSuggestionRepository() { }

        public int GetCountBy(int year, Accomodation accommodation)
        {

            List<RenovationSuggestion> annualRenovationSuggestions = new List<RenovationSuggestion>();

            using (var dbContext = new DataContext())
            {
                annualRenovationSuggestions = dbContext.RenovationSuggestions
                                            .Include(r => r.AccomodationReservation)
                                            
                                            .Where(r => r.AccomodationReservation.CheckInDate.Year == year)
                                            .ToList();
            }

            return annualRenovationSuggestions.Count;
        }

        public int GetCountBy(int year, int month, Accomodation accommodation)
        {

            List<RenovationSuggestion> annualRenovationSuggestions = new List<RenovationSuggestion>();

            using (var dbContext = new DataContext())
            {
                annualRenovationSuggestions = dbContext.RenovationSuggestions
                                            .Include(r => r.AccomodationReservation)
                                            
                                            .Where(r => r.AccomodationReservation.CheckInDate.Year == year && r.AccomodationReservation.CheckInDate.Month == month)
                                            .ToList();
            }

            return annualRenovationSuggestions.Count;
        }
    }
}

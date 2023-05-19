using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Service
{
    public class RenovationSuggestionService
    {

        RenovationSuggestionRepository renovationSuggestionRepository = new RenovationSuggestionRepository  ();
        public RenovationSuggestionService() { }

        public int GetCountBy(int year, Accomodation accommodation)
        {
            return renovationSuggestionRepository.GetCountBy(year, accommodation);
        }

        public int GetCountBy(int year, int month, Accomodation accommodation)
        {
            return renovationSuggestionRepository.GetCountBy(year, month, accommodation);
        }
    }
}

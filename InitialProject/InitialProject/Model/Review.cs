using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Review
    {
        public int RuleCompliance { get; set; }
        public int Cleanliness { get; set; }
        public string Comment { get; set; }

        public Review(int ruleCompliance, int cleanliness, string comment)
        {
            RuleCompliance = ruleCompliance;
            Cleanliness = cleanliness;
            Comment = comment;
        }

        public Review()
        {

        }  
    }
}

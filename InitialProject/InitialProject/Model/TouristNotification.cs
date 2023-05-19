using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class TouristNotification
    {
        [Key]
        public int Id { get; set; }

        public TouristNotificationType Type { get; set; }

        public TouristNotification() { }

    }
}
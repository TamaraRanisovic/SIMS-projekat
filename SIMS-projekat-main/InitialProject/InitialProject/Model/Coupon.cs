﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Coupon
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsUsed { get; set; }
        public Coupon() 
        {   
            Date = DateTime.Now;
            IsUsed = false;
        }

    }
}

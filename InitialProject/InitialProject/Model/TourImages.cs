﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WebApi.Entities;

namespace InitialProject.Model
{
    public class TourImages
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string? URL { get; set; }

        public TourImages() { }

        public TourImages(int id, string name, string url)
        {
            Id = id;
            Name = name;
            URL = url;
        }

        public override string ToString()
        {
            return $"TourImagesId: {Id}\n, Name: {Name}\n, URL: {URL}\n";

        }
    }

    
}

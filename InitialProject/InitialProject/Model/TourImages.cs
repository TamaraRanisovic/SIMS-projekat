using System;
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

        public TourImages(string name, string url)
        {
            Name = name;
            URL = url;
        }

        public TourImages(string url)
        {
            Name = "slika1";
            URL = url;
        }


        public override string ToString()
        {
            return $"TourImagesId: {Id}\n, Name: {Name}\n, URL: {URL}\n";


        }
    }

    
}

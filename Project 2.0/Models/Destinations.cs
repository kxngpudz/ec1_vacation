using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_2._0.Models
{
    public class Destinations
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_2._0.Models
{
    public class FlightsDetails
    {
        public Guid Id { get; set; }
        public string DestinationName { get; set; }
        public DateTime? Time { get; set; }
        public string Destination { get; set; }
        public string LeavingFrom { get; set; }
        
    }
}
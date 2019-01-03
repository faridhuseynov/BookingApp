using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    class Trip
    {
        public string TripName { get; set; }
        public IEnumerable<City> Destinations { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public IEnumerable<TripTask> Checklist { get; set; }
    }
}

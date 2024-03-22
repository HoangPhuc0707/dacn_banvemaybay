using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Seats
    {
        public int SeatID { get; set; }
        public int FlightID { get; set; }
        public string SeatNumber { get; set; }
        public string SeatClass { get; set; }
        public int SeatAvailable { get; set; }
        public virtual Flights Flights { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}

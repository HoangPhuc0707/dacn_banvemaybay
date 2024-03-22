using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Flights
    {
        public int FlightID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime? DepartureDay { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public int? ArrivlaCity { get; set; }
        public int? DepartureCity { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public string HinhAnh { get; set; }
        public string created_by { get; set; }
        public virtual Airports Airports { get; set; }
        public virtual Airports Airports1 { get; set; }
        public virtual ICollection<Fares> Fares { get; set; }    
        public virtual ICollection<Seats> Seats { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
        public virtual AppUser AspNetUser { get; set; }
    }
}

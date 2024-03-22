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
    public class Bookings
    {
        public int BookingID { get; set; }
        public int FlightID { get; set; }
        public int PassengerID { get; set; }
        public int PaymentID { get; set; }
        public int SeatID { get; set; }
        public DateTime? BookingDate { get; set; }
        public bool BookingStatus { get; set; }
        public Decimal TotalPrice { get; set; }
        public string Verification { get; set; }
        public virtual Flights Flights { get; set; }
        public virtual Passengers Passengers { get; set; }
        public virtual Payments Payments { get; set; }
        public virtual Seats Seats { get; set; }    
    }
}

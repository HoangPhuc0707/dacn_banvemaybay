using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Fares
    {
        public int FareID { get; set; }
        public int FlightID { get; set; }
        public string FareType { get; set; }
        public decimal FareAmount { get; set; }
        public virtual Flights Flights { get; set; }
    }
}

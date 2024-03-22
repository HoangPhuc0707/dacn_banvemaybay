using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Airports
    {
        public int AirportID { get; set; }
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string City { get; set; }
        public virtual ICollection<Flights> Flights { get; set; }
        public virtual ICollection<Flights> Flights1 { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Entity
{
    public class Payments
    {
        public int PaymentID { get; set; }

        public DateTime? PaymentDate { get; set; }

        public Decimal? PaymentAmount { get; set; }

        public bool? PaymentMethod { get; set; }
        public virtual ICollection<Bookings> Bookings { get; set; }
    }
}

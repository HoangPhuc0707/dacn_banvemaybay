using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Configurations
{
    public class BookingsConfiguration : IEntityTypeConfiguration<Bookings>
    {
        public void Configure(EntityTypeBuilder<Bookings> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(x => x.BookingID);
            builder.Property(x=>x.BookingID).ValueGeneratedOnAdd();
            builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Flights).WithMany(x => x.Bookings).HasForeignKey(x => x.FlightID);
            builder.HasOne(x => x.Passengers).WithMany(x => x.Bookings).HasForeignKey(x => x.PassengerID);
            builder.HasOne(x => x.Payments).WithMany(x => x.Bookings).HasForeignKey(x => x.PaymentID);
            builder.HasOne(x => x.Seats).WithMany(x => x.Bookings).HasForeignKey(x => x.SeatID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
 
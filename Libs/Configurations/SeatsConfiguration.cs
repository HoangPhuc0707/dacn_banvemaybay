using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Configurations
{
    public class SeatsConfiguration : IEntityTypeConfiguration<Seats>
    {
        public void Configure(EntityTypeBuilder<Seats> builder)
        {
            builder.ToTable("Seats");
            builder.HasKey(x => x.SeatID);
            builder.Property(x => x.SeatID).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Flights).WithMany(x => x.Seats).HasForeignKey(x => x.FlightID);
        }
    }
}

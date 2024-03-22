using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Configurations
{
    public class FlightsConfiguration : IEntityTypeConfiguration<Flights>
    {
        public void Configure(EntityTypeBuilder<Flights> builder)
        {
            builder.ToTable("Flights");
            builder.HasKey(x => x.FlightID);
            builder.Property(x => x.FlightID).ValueGeneratedOnAdd();
            builder.Property(x => x.FlightNumber).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.DepartureDay).HasColumnType("Date");
            builder.HasOne(x => x.Airports).WithMany(x => x.Flights).HasForeignKey(x => x.DepartureCity);
            builder.HasOne(x => x.Airports1).WithMany(x => x.Flights1).HasForeignKey(x => x.ArrivlaCity);
            builder.HasOne(x => x.AspNetUser).WithMany(x => x.Flights).HasForeignKey(x => x.created_by);
        }
    }
}

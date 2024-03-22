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
    public class FaresConfiguration : IEntityTypeConfiguration<Fares>
    {
        public void Configure(EntityTypeBuilder<Fares> builder)
        {
            builder.ToTable("Fares");
            builder.HasKey(x => x.FareID);
            builder.Property(x => x.FareID).ValueGeneratedOnAdd();
            builder.Property(x => x.FareAmount).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Flights).WithMany(x => x.Fares).HasForeignKey(x => x.FlightID);
        }
    }
}

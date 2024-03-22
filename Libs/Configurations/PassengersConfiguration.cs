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
    public class PassengersConfiguration : IEntityTypeConfiguration<Passengers>
    {
        public void Configure(EntityTypeBuilder<Passengers> builder)
        {
            builder.ToTable("Passengers");
            builder.HasKey(x => x.PassengerID);
            builder.Property(x => x.PassengerID).ValueGeneratedOnAdd();
        }
    }
}

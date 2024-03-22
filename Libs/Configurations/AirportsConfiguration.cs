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
    public class AirportsConfiguration : IEntityTypeConfiguration<Airports>
    {
        public void Configure(EntityTypeBuilder<Airports> builder)
        {
            builder.ToTable("Airports");
            builder.HasKey(x => x.AirportID);
            builder.Property(x => x.AirportID).ValueGeneratedOnAdd();
            
        }
    }
}

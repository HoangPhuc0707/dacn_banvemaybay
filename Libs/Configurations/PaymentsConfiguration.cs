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
    public class PaymentsConfiguration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.PaymentID);
            builder.Property(x => x.PaymentID).ValueGeneratedOnAdd();
            builder.Property(x=>x.PaymentAmount).HasColumnType("decimal(18,2)");
        }
    }
}

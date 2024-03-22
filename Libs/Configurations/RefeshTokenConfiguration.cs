using Libs.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Configurations
{
    public class RefeshTokenConfiguration : IEntityTypeConfiguration<RefeshToken>
    {
        public void Configure(EntityTypeBuilder<RefeshToken> builder)
        {
            builder.ToTable("RefeshToken");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

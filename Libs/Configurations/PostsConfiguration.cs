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
    public class PostsConfiguration:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(x => x.PostID);
            builder.Property(x => x.PostID).ValueGeneratedOnAdd();
            builder.HasOne(x=>x.Topic).WithMany(x => x.Posts).HasForeignKey(x => x.PostID);
            builder.HasOne(x => x.AspNetUser).WithMany(x => x.Posts).HasForeignKey(x => x.created_by);
        }
    }
}

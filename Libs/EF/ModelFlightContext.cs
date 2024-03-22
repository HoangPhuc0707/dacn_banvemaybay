using Libs.Configurations;
using Libs.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Libs.EF
{
    public class ModelFlightContext : IdentityDbContext<AppUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new FlightsConfiguration());
            modelBuilder.ApplyConfiguration(new BookingsConfiguration());
            modelBuilder.ApplyConfiguration(new AirportsConfiguration());
            modelBuilder.ApplyConfiguration(new FaresConfiguration());
            modelBuilder.ApplyConfiguration(new PassengersConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            modelBuilder.ApplyConfiguration(new PostsConfiguration());
            modelBuilder.ApplyConfiguration(new SeatsConfiguration());
            modelBuilder.ApplyConfiguration(new TopicsConfiguration());
            modelBuilder.ApplyConfiguration(new RefeshTokenConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public ModelFlightContext(DbContextOptions<ModelFlightContext> options) : base(options)
        {
        }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Fares> Fares { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<RefeshToken> RefeshToken { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Topic> Topic { get; set; }
    }

}

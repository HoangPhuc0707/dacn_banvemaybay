﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.EF
{
    public class ModelFlightContextFactory : IDesignTimeDbContextFactory<ModelFlightContext>
    {
        public ModelFlightContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ModelFlightContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ModelFlightContext(optionsBuilder.Options);
        }
    }
}

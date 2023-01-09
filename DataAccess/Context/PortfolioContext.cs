using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Context
{
    public class PortfolioContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=;database=Portfolio")
                .UseLoggerFactory(LoggerFactory.Create(b => b
                 .AddFilter(level => level >= LogLevel.Information))).EnableSensitiveDataLogging().EnableDetailedErrors();
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<AdminAddress> AdminAddresses { get; set; }
        public virtual DbSet<AdminEmail> AdminEmails { get; set; }
        public virtual DbSet<AdminPhoneNumber> AdminPhoneNumbers { get; set; }
        public virtual DbSet<MyService> MyServices { get; set; }
        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<Icon> Icons { get; set; }
        public virtual DbSet<FooterImage> FooterImages { get; set; }

    }
}

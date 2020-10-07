using System;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webshop.Domain;

namespace Webshop.Data
{
    public class WebshopContext : DbContext
    {

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<ProductEdition> ProductEditions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }



        public WebshopContext(DbContextOptions<WebshopContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public WebshopContext()
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().Ignore(b => b.Password);           
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WebshopData");
        //}





        //public static readonly ILoggerFactory ConsoleLoggerFactory
    }
}

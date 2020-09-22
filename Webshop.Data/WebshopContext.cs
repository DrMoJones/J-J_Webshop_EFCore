using System;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webshop.Domain;

namespace Webshop.Data
{
    public class WebshopContext : DbContext
    {

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

        //public WebshopContext(DbContextOptions options)
        //{

        //}

        public WebshopContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = WebshopData");
        //}





        //public static readonly ILoggerFactory ConsoleLoggerFactory
    }
}

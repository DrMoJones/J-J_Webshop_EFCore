using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webshop.Domain;

namespace Webshop.Data
{
    public class WebshopContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<ProductVersion> ProductVersions { get; set; }

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

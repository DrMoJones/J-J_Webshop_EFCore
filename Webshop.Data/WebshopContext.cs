using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webshop.Domain;

namespace Webshop.Data
{
    public class WebshopContext : DbContext
    {

        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

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

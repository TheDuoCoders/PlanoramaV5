using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class EMSContext : DbContext
    {
        public DbSet<FoodsCategory> FoodsCategories { get; set;}
        public DbSet<Food> Foods { get; set;}
        public DbSet<DecorationsCategory> DecorationsCategories {  get; set;}
        public DbSet<Decoration> Decorations { get; set; }
        public DbSet<LocationsCategory> LocationsCategories { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<CustomPackage> CustomPackages { get; set; }

    }
}

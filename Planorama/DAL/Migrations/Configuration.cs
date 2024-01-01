namespace DAL.Migrations
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Models.EMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.Models.EMSContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            DateTime currentDate = DateTime.Now;
            Random random = new Random();


            //foodCategory (6 categories)
            for (int i = 1; i <= 6; i++)
            {
                context.FoodsCategories.AddOrUpdate(new Models.FoodsCategory
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0,15),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),

                }) ;
            }

            //food (20 categories)
            for (int i = 1; i <= 20; i++)
            {
                context.Foods.AddOrUpdate(new Models.Food
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    FoodCategory = random.Next(1, 6),
                    Picture = Guid.NewGuid().ToString().Substring(0, 10),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),
                    Price = random.Next(2, 6) * 100,
                    TimesSelected = random.Next(10, 50),
                });
            }


            //DecorationCategory (6 categories)
            for (int i = 1; i <= 6; i++)
            {
                context.DecorationsCategories.AddOrUpdate(new Models.DecorationsCategory
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),

                });
            }

            //Decoration (20 categories)
            for (int i = 1; i <= 20; i++)
            {
                context.Decorations.AddOrUpdate(new Models.Decoration
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    DecorationCategory = random.Next(1, 6),
                    Picture = Guid.NewGuid().ToString().Substring(0, 10),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),                    
                    Price = random.Next(2, 6) * 10000,
                    TimesSelected = random.Next(10, 50),


                });
            }

            //LocationCategory (6 categories)
            for (int i = 1; i <= 6; i++)
            {
                context.LocationsCategories.AddOrUpdate(new Models.LocationsCategory
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),

                });
            }

            //Location (20 categories)
            for (int i = 1; i <= 20; i++)
            {
                context.Locations.AddOrUpdate(new Models.Location
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    LocationCategory = random.Next(1, 6),
                    Picture = Guid.NewGuid().ToString().Substring(0, 10),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),
                    Price = random.Next(2, 6) * 10000,
                    TimesSelected = random.Next(10, 50),


                });
            }


            //-----------------------------------------------------------

            //user table (10 users)


            for (int i = 1; i <= 10; i++)
            {
                int randomAge = random.Next(18, 51);
                context.Users.AddOrUpdate(new Models.User
                {
                    Uname = "User-" + i,
                    Name = Guid.NewGuid().ToString().Substring(0, 15),
                    Password = Guid.NewGuid().ToString().Substring(0, 15),
                    DOB = currentDate.AddYears(-randomAge),
                    Phone = Guid.NewGuid().ToString().Substring(0, 11),
                    Address = Guid.NewGuid().ToString().Substring(0, 20),
                    Points = 0,
                    UserType = "General",

                });
            }

            //review table (5 reviews)
            for (int i = 1; i <= 5; i++)
            {
                
                context.Reviews.AddOrUpdate(new Models.Review
                {
                    Id = i,
                    PostedBy = "User-"+random.Next(1, 6),
                    PostedTime = DateTime.Now,
                    ReviewText = Guid.NewGuid().ToString().Substring(0,20),
                });
            }

            //Coupon table (5 coupons)
            for (int i = 1; i <= 5; i++)
            {

                context.Coupons.AddOrUpdate(new Models.Coupon
                {
                    Id = i,
                    CouponText = Guid.NewGuid().ToString().Substring(0, 5),
                    Validity = DateTime.Now.AddMonths(i),
                    DiscountPercentage = random.Next(1, 6)*5,
                });
            }

            //Package table (10 Packages)
            for (int i = 1; i <= 10; i++)
            {
                context.Packages.AddOrUpdate(new Models.Package
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Photo = Guid.NewGuid().ToString().Substring(0,10),
                    Description = Guid.NewGuid().ToString().Substring(0,20),
                    Price = random.Next(50, 1500)*1000,
                    FoodId = random.Next(1, 21),
                    DecorationId = random.Next(1, 21),
                    LocationId = random.Next(1, 21),
                    GuestAmount = random.Next(1, 50) * 100,
                });
            }


            //Custom Package table (5 Custom Packages)
            for (int i = 1; i <= 5; i++)
            {
                context.Packages.AddOrUpdate(new Models.Package
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString().Substring(0, 10),
                    Photo = Guid.NewGuid().ToString().Substring(0, 10),
                    Description = Guid.NewGuid().ToString().Substring(0, 20),
                    Price = random.Next(50, 1500) * 1000,
                    FoodId = random.Next(1, 21),
                    DecorationId = random.Next(1, 21),
                    LocationId = random.Next(1, 21),
                    GuestAmount = random.Next(1, 50) * 100,
                });
            }

            //Notification table (5 Notification)
            for (int i = 1; i <= 5; i++)
            {
                context.Notifications.AddOrUpdate(new Models.Notification
                {
                    Id = i,
                    NotificationMessage = Guid.NewGuid().ToString().Substring(0, 20),
                    NotificationTime = DateTime.Now,
                    NotifiedUser = "User-" + random.Next(1, 6),
                });
            }

            //Booking table (5 Booking)
            for (int i = 1; i <= 5; i++)
            {
                context.Bookings.AddOrUpdate(new Models.Booking
                {
                    Id = i,
                    PackageId = random.Next(1, 10),
                    Price = random.Next(50, 1500) * 1000,
                    OrderedBy = "User-" + random.Next(1, 6),
                    CouponId = 0,
                    OrderTime = DateTime.Now,
                });
            }


        }
    }
}

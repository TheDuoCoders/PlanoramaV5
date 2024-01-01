namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_basiceFileAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PackageId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        OrderedBy = c.String(nullable: false, maxLength: 128),
                        OrderTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OrderedBy, cascadeDelete: true)
                .Index(t => t.OrderedBy);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Uname = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                        Address = c.String(nullable: false, maxLength: 50),
                        Points = c.Int(nullable: false),
                        UserType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Uname);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NotificationMessage = c.String(nullable: false),
                        NotifiedUser = c.String(nullable: false, maxLength: 128),
                        NotificationTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.NotifiedUser, cascadeDelete: true)
                .Index(t => t.NotifiedUser);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReviewText = c.String(nullable: false),
                        PostedBy = c.String(nullable: false, maxLength: 128),
                        PostedTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PostedBy, cascadeDelete: true)
                .Index(t => t.PostedBy);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CouponText = c.String(nullable: false),
                        DiscountPercentage = c.Int(nullable: false),
                        Validity = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Decorations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        DecorationCategory = c.Int(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                        Price = c.Double(nullable: false),
                        TimesSelected = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DecorationsCategories", t => t.DecorationCategory, cascadeDelete: true)
                .Index(t => t.DecorationCategory);
            
            CreateTable(
                "dbo.DecorationsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        FoodCategory = c.Int(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                        Price = c.Double(nullable: false),
                        TimesSelected = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FoodsCategories", t => t.FoodCategory, cascadeDelete: true)
                .Index(t => t.FoodCategory);
            
            CreateTable(
                "dbo.FoodsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        LocationCategory = c.Int(nullable: false),
                        Picture = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                        Price = c.Double(nullable: false),
                        TimesSelected = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LocationsCategories", t => t.LocationCategory, cascadeDelete: true)
                .Index(t => t.LocationCategory);
            
            CreateTable(
                "dbo.LocationsCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 20),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "LocationCategory", "dbo.LocationsCategories");
            DropForeignKey("dbo.Foods", "FoodCategory", "dbo.FoodsCategories");
            DropForeignKey("dbo.Decorations", "DecorationCategory", "dbo.DecorationsCategories");
            DropForeignKey("dbo.Bookings", "OrderedBy", "dbo.Users");
            DropForeignKey("dbo.Reviews", "PostedBy", "dbo.Users");
            DropForeignKey("dbo.Notifications", "NotifiedUser", "dbo.Users");
            DropIndex("dbo.Locations", new[] { "LocationCategory" });
            DropIndex("dbo.Foods", new[] { "FoodCategory" });
            DropIndex("dbo.Decorations", new[] { "DecorationCategory" });
            DropIndex("dbo.Reviews", new[] { "PostedBy" });
            DropIndex("dbo.Notifications", new[] { "NotifiedUser" });
            DropIndex("dbo.Bookings", new[] { "OrderedBy" });
            DropTable("dbo.LocationsCategories");
            DropTable("dbo.Locations");
            DropTable("dbo.FoodsCategories");
            DropTable("dbo.Foods");
            DropTable("dbo.DecorationsCategories");
            DropTable("dbo.Decorations");
            DropTable("dbo.Coupons");
            DropTable("dbo.Reviews");
            DropTable("dbo.Notifications");
            DropTable("dbo.Users");
            DropTable("dbo.Bookings");
        }
    }
}

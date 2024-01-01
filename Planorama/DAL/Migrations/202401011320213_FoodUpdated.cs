namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FoodUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Photo = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        FoodId = c.Int(nullable: false),
                        DecorationId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        GuestAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Decorations", t => t.DecorationId, cascadeDelete: true)
                .ForeignKey("dbo.Foods", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.DecorationId)
                .Index(t => t.LocationId);
            
            AddColumn("dbo.Bookings", "CustomPackage_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "CustomPackage_Id");
            AddForeignKey("dbo.Bookings", "CustomPackage_Id", "dbo.CustomPackages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomPackages", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.CustomPackages", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.CustomPackages", "DecorationId", "dbo.Decorations");
            DropForeignKey("dbo.Bookings", "CustomPackage_Id", "dbo.CustomPackages");
            DropIndex("dbo.CustomPackages", new[] { "LocationId" });
            DropIndex("dbo.CustomPackages", new[] { "DecorationId" });
            DropIndex("dbo.CustomPackages", new[] { "FoodId" });
            DropIndex("dbo.Bookings", new[] { "CustomPackage_Id" });
            DropColumn("dbo.Bookings", "CustomPackage_Id");
            DropTable("dbo.CustomPackages");
        }
    }
}

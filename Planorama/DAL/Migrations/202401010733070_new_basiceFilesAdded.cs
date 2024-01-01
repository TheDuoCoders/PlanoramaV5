namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_basiceFilesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Packages",
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
            
            CreateIndex("dbo.Bookings", "PackageId");
            AddForeignKey("dbo.Bookings", "PackageId", "dbo.Packages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PackageId", "dbo.Packages");
            DropForeignKey("dbo.Packages", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Packages", "FoodId", "dbo.Foods");
            DropForeignKey("dbo.Packages", "DecorationId", "dbo.Decorations");
            DropIndex("dbo.Packages", new[] { "LocationId" });
            DropIndex("dbo.Packages", new[] { "DecorationId" });
            DropIndex("dbo.Packages", new[] { "FoodId" });
            DropIndex("dbo.Bookings", new[] { "PackageId" });
            DropTable("dbo.Packages");
        }
    }
}

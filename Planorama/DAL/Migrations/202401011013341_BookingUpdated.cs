
namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CouponId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "CouponId");
            AddForeignKey("dbo.Bookings", "CouponId", "dbo.Coupons", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Bookings", new[] { "CouponId" });
            DropColumn("dbo.Bookings", "CouponId");
        }
    }
}

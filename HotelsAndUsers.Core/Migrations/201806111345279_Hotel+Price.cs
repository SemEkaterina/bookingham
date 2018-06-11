namespace HotelsAndUsers.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HotelPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hotels", "MinPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hotels", "MinPrice");
        }
    }
}

namespace HotelsAndUsers.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteIdHotel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "HotelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "HotelId", c => c.Int(nullable: false));
        }
    }
}

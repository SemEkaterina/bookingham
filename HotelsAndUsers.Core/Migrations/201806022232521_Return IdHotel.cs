namespace HotelsAndUsers.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReturnIdHotel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "IdHotel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "IdHotel");
        }
    }
}

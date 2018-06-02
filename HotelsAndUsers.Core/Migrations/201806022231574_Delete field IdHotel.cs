namespace HotelsAndUsers.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletefieldIdHotel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Rooms", "IdHotel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rooms", "IdHotel", c => c.Int(nullable: false));
        }
    }
}

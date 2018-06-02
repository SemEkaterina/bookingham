namespace HotelsAndUsers.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingTime = c.DateTime(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Hotel_Id = c.Int(),
                        Room_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .ForeignKey("dbo.Rooms", t => t.Room_Id)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Room_Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stars = c.Int(nullable: false),
                        Type = c.String(),
                        Address = c.String(),
                        District = c.String(),
                        Description = c.String(),
                        PhoneNumber = c.String(),
                        CheckInTime = c.String(),
                        CheckOutTime = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        PriceForNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Class = c.String(),
                        BedNumber = c.Int(nullable: false),
                        Hotel_Id = c.Int(),
                        Hotel_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id1)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Hotel_Id1);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoomId = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                        Guest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guests", t => t.Guest_Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.Guest_Id);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        MyProperty = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        PassportId = c.String(),
                        PassportNumber = c.String(),
                        PreviousBookings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Room_Id", "dbo.Rooms");
            DropForeignKey("dbo.Bookings", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "Hotel_Id1", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Reservations", "Guest_Id", "dbo.Guests");
            DropIndex("dbo.Reservations", new[] { "Guest_Id" });
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "Hotel_Id1" });
            DropIndex("dbo.Rooms", new[] { "Hotel_Id" });
            DropIndex("dbo.Bookings", new[] { "Room_Id" });
            DropIndex("dbo.Bookings", new[] { "Hotel_Id" });
            DropTable("dbo.Guests");
            DropTable("dbo.Reservations");
            DropTable("dbo.Rooms");
            DropTable("dbo.Hotels");
            DropTable("dbo.Bookings");
        }
    }
}

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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .Index(t => t.Hotel_Id);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Stars = c.Int(nullable: false),
                        Type = c.String(),
                        HotelImagePath = c.String(),
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
                        Class = c.String(),
                        BedNumber = c.Int(nullable: false),
                        PriceForNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Hotel_Id = c.Int(),
                        Hotel_Id1 = c.Int(),
                        Booking_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id1)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Hotel_Id1)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                        PassportId = c.String(),
                        PassportNumber = c.String(),
                        PreviousBookingsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "Hotel_Id1", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "Hotel_Id", "dbo.Hotels");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "Booking_Id" });
            DropIndex("dbo.Rooms", new[] { "Hotel_Id1" });
            DropIndex("dbo.Rooms", new[] { "Hotel_Id" });
            DropIndex("dbo.Bookings", new[] { "Hotel_Id" });
            DropTable("dbo.Guests");
            DropTable("dbo.Reservations");
            DropTable("dbo.Rooms");
            DropTable("dbo.Hotels");
            DropTable("dbo.Bookings");
        }
    }
}

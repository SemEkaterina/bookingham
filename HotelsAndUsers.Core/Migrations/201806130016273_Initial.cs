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
                        BookingId = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                        BookingTime = c.DateTime(nullable: false),
                        CheckIn = c.DateTime(nullable: false),
                        CheckOut = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookingId)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        HotelId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        Class = c.String(),
                        BedNumber = c.Int(nullable: false),
                        PriceForNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Booking_BookingId = c.Int(),
                        Hotel_HotelId = c.Int(),
                        Hotel_HotelId1 = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Bookings", t => t.Booking_BookingId)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId)
                .ForeignKey("dbo.Hotels", t => t.Hotel_HotelId1)
                .Index(t => t.Booking_BookingId)
                .Index(t => t.Hotel_HotelId)
                .Index(t => t.Hotel_HotelId1);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        CheckInDate = c.DateTime(nullable: false),
                        CheckOutDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        GuestId = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Country = c.String(),
                        PassportId = c.String(),
                        PassportNumber = c.String(),
                    })
                .PrimaryKey(t => t.GuestId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
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
                        MinPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.HotelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "Hotel_HotelId1", "dbo.Hotels");
            DropForeignKey("dbo.Rooms", "Hotel_HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Bookings", "GuestId", "dbo.Guests");
            DropForeignKey("dbo.Rooms", "Booking_BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Reservations", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Reservations", new[] { "RoomId" });
            DropIndex("dbo.Rooms", new[] { "Hotel_HotelId1" });
            DropIndex("dbo.Rooms", new[] { "Hotel_HotelId" });
            DropIndex("dbo.Rooms", new[] { "Booking_BookingId" });
            DropIndex("dbo.Bookings", new[] { "GuestId" });
            DropTable("dbo.Hotels");
            DropTable("dbo.Guests");
            DropTable("dbo.Reservations");
            DropTable("dbo.Rooms");
            DropTable("dbo.Bookings");
        }
    }
}

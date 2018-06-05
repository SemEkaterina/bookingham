namespace HotelsAndUsers.Core.Migrations
{
    using HotelsAndUsers.Core.Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelsAndUsers.Core.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelsAndUsers.Core.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<Hotel> ReadHotels = new List<Hotel>();
            List<Room> ReadRooms = new List<Room>();
            //List<Guest> ReadUsers = new List<Guest>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceNameTimetable = "HotelsAndUsers.Core.hotels.json";
            using (Stream stream = assembly.GetManifestResourceStream(resourceNameTimetable))
            {
                using (StreamReader sr = new StreamReader(stream, System.Text.Encoding.GetEncoding(1251)))
                {
                    using (var jsonReader = new JsonTextReader(sr))
                    {
                        var serializer = new JsonSerializer();
                        ReadHotels = serializer.Deserialize<List<Hotel>>(jsonReader);
                    }
                }
            }

            foreach (var hotel in ReadHotels)
            {
                context.Hotels.Add(hotel);
            }

            foreach (var hotel in ReadHotels)
            {
                foreach (var room in ReadRooms)
                {
                    context.Rooms.Add(room);
                }
            }
            context.SaveChanges();

        }
    }
}

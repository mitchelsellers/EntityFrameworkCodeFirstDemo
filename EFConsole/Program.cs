using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EfDemoDataTier;
using EfDemoDataTier.Models;

namespace EFConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var myContext = new DemoContext())
            {
                //var toInsert = new Campus() { CampusName = "Test Campus 1" };
                //myContext.Campuses.Add(toInsert);

                //Multi insert
                //for (int i = 2; i < 35; i++)
                //{
                //    var toInsert2 = new Campus() { CampusName = "Test Campus " + i };
                //    myContext.Campuses.Add(toInsert2);
                //}
                //myContext.SaveChanges();

                //Multi insert
                //for (int i = 4; i < 35; i++)
                //{
                //    var toInsert = new Classroom() { RoomName = string.Format("Room {0} - {0}", i), RoomCapacity = i * 10, CampusId = i, RoomNumber = i };
                //    myContext.Classrooms.Add(toInsert);
                //}
                //myContext.SaveChanges();

                //var foundSchools = from x in myContext.Campuses
                //                   orderby x.CampusName
                //                   select x;

                ////Query not yet ran
                //foreach (var item in foundSchools.Skip(2).Take(20))
                //    Console.WriteLine(item.CampusName);

                //More complex query
                var foundRooms = from x in myContext.Classrooms.Include(x => x.Campus)
                                 where x.Campus.CampusName.StartsWith("Test Campus 2")
                                 orderby x.RoomName
                                 select x;
                foreach (var room in foundRooms)
                    Console.WriteLine(room.RoomName + " - " + room.Campus.CampusName);

                //Projection Example
                var foundRoomsProjection = from x in myContext.Classrooms.Include(x => x.Campus)
                    where x.Campus.CampusName.StartsWith("Test Campus 2")
                    orderby x.RoomName
                    select new
                    {
                        CampusName = x.Campus.CampusName,
                        RoomName = x.RoomName,
                        CampusAddress = x.Campus.CampusAddress
                    };

                foreach (var room in foundRoomsProjection)
                    Console.WriteLine(room.CampusName + " - " + room.CampusAddress);

                Console.WriteLine("Done");
                Console.ReadLine();


            }
        }
    }
}

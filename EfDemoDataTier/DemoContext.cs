using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfDemoDataTier.Models;

namespace EfDemoDataTier
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("EFDemoConnectionString")
        {
            //Constructor used to override expected connection string

            //If you want to disable initialization
            //Database.SetInitializer<DemoContext>(null);
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        //public DbSet<Employee> Employees { get; set; }
    }
}

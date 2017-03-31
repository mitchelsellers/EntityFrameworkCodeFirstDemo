namespace EfDemoDataTier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        CampusId = c.Int(nullable: false),
                        EmployeeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .Index(t => t.CampusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "CampusId", "dbo.Campus");
            DropIndex("dbo.Employees", new[] { "CampusId" });
            DropTable("dbo.Employees");
        }
    }
}

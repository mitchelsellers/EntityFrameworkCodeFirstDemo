namespace EfDemoDataTier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campus",
                c => new
                    {
                        CampusId = c.Int(nullable: false, identity: true),
                        CampusName = c.String(nullable: false, maxLength: 75),
                        CampusAddress = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.CampusId)
                .Index(t => t.CampusName, unique: true);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        CampusId = c.Int(nullable: false),
                        RoomNumber = c.Int(nullable: false),
                        RoomCapacity = c.Int(),
                        RoomName = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ClassroomId)
                .ForeignKey("dbo.Campus", t => t.CampusId, cascadeDelete: true)
                .Index(t => t.CampusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classrooms", "CampusId", "dbo.Campus");
            DropIndex("dbo.Classrooms", new[] { "CampusId" });
            DropIndex("dbo.Campus", new[] { "CampusName" });
            DropTable("dbo.Classrooms");
            DropTable("dbo.Campus");
        }
    }
}

namespace pro6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        SchoolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        SchoolId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.SchoolId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(unicode: false),
                        ClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Classes", t => t.ClassId, cascadeDelete: true)
                .Index(t => t.ClassId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropForeignKey("dbo.Classes", "SchoolId", "dbo.Schools");
            DropIndex("dbo.Students", new[] { "ClassId" });
            DropIndex("dbo.Classes", new[] { "SchoolId" });
            DropTable("dbo.Students");
            DropTable("dbo.Schools");
            DropTable("dbo.Classes");
        }
    }
}

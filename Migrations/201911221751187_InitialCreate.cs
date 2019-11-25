namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.researches",
                c => new
                    {
                        reID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Topic = c.String(),
                        Details = c.String(),
                        research_reID = c.Int(),
                    })
                .PrimaryKey(t => t.reID)
                .ForeignKey("dbo.researches", t => t.research_reID)
                .Index(t => t.research_reID);
            
            CreateTable(
                "dbo.resolutions",
                c => new
                    {
                        resID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Topic = c.String(),
                        Details = c.String(),
                        resolution_resID = c.Int(),
                    })
                .PrimaryKey(t => t.resID)
                .ForeignKey("dbo.resolutions", t => t.resolution_resID)
                .Index(t => t.resolution_resID);
            
            CreateTable(
                "dbo.secures",
                c => new
                    {
                        secID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Topic = c.String(),
                        Details = c.String(),
                        secure_secID = c.Int(),
                    })
                .PrimaryKey(t => t.secID)
                .ForeignKey("dbo.secures", t => t.secure_secID)
                .Index(t => t.secure_secID);
            
            CreateTable(
                "dbo.vulnerabilities",
                c => new
                    {
                        vulID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.String(),
                        Topic = c.String(),
                        Details = c.String(),
                        vulnerability_vulID = c.Int(),
                    })
                .PrimaryKey(t => t.vulID)
                .ForeignKey("dbo.vulnerabilities", t => t.vulnerability_vulID)
                .Index(t => t.vulnerability_vulID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.vulnerabilities", "vulnerability_vulID", "dbo.vulnerabilities");
            DropForeignKey("dbo.secures", "secure_secID", "dbo.secures");
            DropForeignKey("dbo.resolutions", "resolution_resID", "dbo.resolutions");
            DropForeignKey("dbo.researches", "research_reID", "dbo.researches");
            DropIndex("dbo.vulnerabilities", new[] { "vulnerability_vulID" });
            DropIndex("dbo.secures", new[] { "secure_secID" });
            DropIndex("dbo.resolutions", new[] { "resolution_resID" });
            DropIndex("dbo.researches", new[] { "research_reID" });
            DropTable("dbo.vulnerabilities");
            DropTable("dbo.secures");
            DropTable("dbo.resolutions");
            DropTable("dbo.researches");
        }
    }
}

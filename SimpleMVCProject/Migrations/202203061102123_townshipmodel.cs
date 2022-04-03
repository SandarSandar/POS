namespace SimpleMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class townshipmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Township",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        ZipCode = c.String(),
                        CityId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId)
                .Index(t => t.CityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Township", "CityId", "dbo.City");
            DropIndex("dbo.Township", new[] { "CityId" });
            DropTable("dbo.Township");
        }
    }
}

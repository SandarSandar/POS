namespace SimpleMVCProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnewcolumnsinStudentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "No", c => c.String());
            AddColumn("dbo.Student", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Student", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Student", "IsDelete", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "IsDelete");
            DropColumn("dbo.Student", "UpdatedDate");
            DropColumn("dbo.Student", "CreateDate");
            DropColumn("dbo.Student", "No");
        }
    }
}

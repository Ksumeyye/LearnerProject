namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateImageUrlColumnInTeachersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "ImageUrl");
        }
    }
}

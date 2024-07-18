namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateBranchColumnInTeachersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Branch", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Branch");
        }
    }
}

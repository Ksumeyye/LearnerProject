namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteItem2AndItem3ColumnInAboutsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Abouts", "Item2");
            DropColumn("dbo.Abouts", "Item3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abouts", "Item3", c => c.String());
            AddColumn("dbo.Abouts", "Item2", c => c.String());
        }
    }
}

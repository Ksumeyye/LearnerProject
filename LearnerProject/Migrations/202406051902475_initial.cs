namespace LearnerProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Item1 = c.String(),
                        Item2 = c.String(),
                        Item3 = c.String(),
                    })
                .PrimaryKey(t => t.AboutId);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Banners",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.BannerId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Icon = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        ImageUrl = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.CourseRegisters",
                c => new
                    {
                        CourseRegisterId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseRegisterId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ReviewValue = c.Double(nullable: false),
                        Comment = c.String(),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CourseVideos",
                c => new
                    {
                        CourseVideoId = c.Int(nullable: false, identity: true),
                        VideoNumber = c.Int(nullable: false),
                        VideoUrl = c.String(),
                        CourseId = c.Int(nullable: false),
                        TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseVideoId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Classrooms",
                c => new
                    {
                        ClassroomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Icon = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ClassroomId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        OpenHours = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        FAQId = c.Int(nullable: false, identity: true),
                        Question = c.String(),
                        Answer = c.String(),
                        ImageUrl = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FAQId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Email = c.String(),
                        Subject = c.String(),
                        MessageContent = c.String(),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.SocialMedias",
                c => new
                    {
                        SocialMediaId = c.Int(nullable: false, identity: true),
                        SocialMediaName = c.String(),
                        SocialMediaUrl = c.String(),
                        Icon = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SocialMediaId);
            
            CreateTable(
                "dbo.Testimonials",
                c => new
                    {
                        TestimonialId = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(),
                        Title = c.String(),
                        ImageUrl = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.TestimonialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseVideos", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.CourseVideos", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Reviews", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Reviews", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseRegisters", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseRegisters", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.CourseVideos", new[] { "TeacherId" });
            DropIndex("dbo.CourseVideos", new[] { "CourseId" });
            DropIndex("dbo.Reviews", new[] { "StudentId" });
            DropIndex("dbo.Reviews", new[] { "CourseId" });
            DropIndex("dbo.CourseRegisters", new[] { "CourseId" });
            DropIndex("dbo.CourseRegisters", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropTable("dbo.Testimonials");
            DropTable("dbo.SocialMedias");
            DropTable("dbo.Messages");
            DropTable("dbo.FAQs");
            DropTable("dbo.Contacts");
            DropTable("dbo.Classrooms");
            DropTable("dbo.Teachers");
            DropTable("dbo.CourseVideos");
            DropTable("dbo.Reviews");
            DropTable("dbo.Students");
            DropTable("dbo.CourseRegisters");
            DropTable("dbo.Courses");
            DropTable("dbo.Categories");
            DropTable("dbo.Banners");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}

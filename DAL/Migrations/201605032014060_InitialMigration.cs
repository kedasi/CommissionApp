namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArtExamples",
                c => new
                    {
                        ArtExampleId = c.Int(nullable: false, identity: true),
                        ArtExampleUrl = c.String(maxLength: 500),
                        ArtExampleComment = c.String(maxLength: 500),
                        ArtExampleDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                        Tag_TagId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtExampleId)
                .ForeignKey("dbo.Tags", t => t.Tag_TagId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Pictures", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PictureId)
                .Index(t => t.Tag_TagId);
            
            CreateTable(
                "dbo.ArtExampleTags",
                c => new
                    {
                        ArtExampleTagId = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        ArtExampleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtExampleTagId)
                .ForeignKey("dbo.ArtExamples", t => t.ArtExampleId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.ArtExampleId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagText = c.String(maxLength: 24),
                        TagTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TagId)
                .ForeignKey("dbo.TagTypes", t => t.TagTypeId, cascadeDelete: true)
                .Index(t => t.TagTypeId);
            
            CreateTable(
                "dbo.TagTypes",
                c => new
                    {
                        TagTypeId = c.Int(nullable: false, identity: true),
                        TagTypeValue = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.TagTypeId);
            
            CreateTable(
                "dbo.UserTags",
                c => new
                    {
                        UserTagId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserTagId)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 24),
                        Password = c.String(maxLength: 24),
                        Birthdate = c.Int(nullable: false),
                        Country = c.String(maxLength: 24),
                        UserTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserTypes", t => t.UserTypeId, cascadeDelete: true)
                .Index(t => t.UserTypeId);
            
            CreateTable(
                "dbo.CreditCardUsers",
                c => new
                    {
                        CreditCardUserId = c.Int(nullable: false, identity: true),
                        CreditCardInfoId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardUserId)
                .ForeignKey("dbo.CreditCardInfoes", t => t.CreditCardInfoId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.CreditCardInfoId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CreditCardInfoes",
                c => new
                    {
                        CreditCardInfoId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 24),
                        LastName = c.String(maxLength: 24),
                        CreditCardNumber = c.Int(nullable: false),
                        SecurityNumber = c.Int(nullable: false),
                        ExpirationDate = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditCardInfoId);
            
            CreateTable(
                "dbo.UserFeedbacks",
                c => new
                    {
                        UserFeedbackId = c.Int(nullable: false, identity: true),
                        Stars = c.Int(nullable: false),
                        Comment = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserFeedbackId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTypes",
                c => new
                    {
                        UserTypeId = c.Int(nullable: false, identity: true),
                        UserTypeValue = c.String(maxLength: 24),
                    })
                .PrimaryKey(t => t.UserTypeId);
            
            CreateTable(
                "dbo.ArtMessages",
                c => new
                    {
                        ArtMessageId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 24),
                        ArtMessageText = c.String(),
                        UserMessageId = c.Int(nullable: false),
                        ArtExampleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArtMessageId)
                .ForeignKey("dbo.ArtExamples", t => t.ArtExampleId, cascadeDelete: true)
                .ForeignKey("dbo.UserMessages", t => t.UserMessageId, cascadeDelete: true)
                .Index(t => t.UserMessageId)
                .Index(t => t.ArtExampleId);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        UserMessageId = c.Int(nullable: false, identity: true),
                        UserMessageTitle = c.String(maxLength: 24),
                        UserMessageText = c.String(),
                    })
                .PrimaryKey(t => t.UserMessageId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureId = c.Int(nullable: false, identity: true),
                        PictureUrl = c.String(maxLength: 500),
                        PictureDate = c.DateTime(nullable: false),
                        PictureComment = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.PictureId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectDate = c.DateTime(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Pictures", t => t.PictureId, cascadeDelete: true)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.ProjectStatusReports",
                c => new
                    {
                        ProjectStatusReportId = c.Int(nullable: false, identity: true),
                        ProjectStatus = c.String(maxLength: 24),
                        ProjectStatusDate = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectStatusReportId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectStatusReportComments",
                c => new
                    {
                        ProjectStatusReportCommentId = c.Int(nullable: false, identity: true),
                        ProjectStatusComment = c.String(),
                        ProjectStatusReportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectStatusReportCommentId)
                .ForeignKey("dbo.ProjectStatusReports", t => t.ProjectStatusReportId, cascadeDelete: true)
                .Index(t => t.ProjectStatusReportId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectStatusReportComments", "ProjectStatusReportId", "dbo.ProjectStatusReports");
            DropForeignKey("dbo.ProjectStatusReports", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "PictureId", "dbo.Pictures");
            DropForeignKey("dbo.ArtExamples", "PictureId", "dbo.Pictures");
            DropForeignKey("dbo.ArtMessages", "UserMessageId", "dbo.UserMessages");
            DropForeignKey("dbo.ArtMessages", "ArtExampleId", "dbo.ArtExamples");
            DropForeignKey("dbo.ArtExampleTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Users", "UserTypeId", "dbo.UserTypes");
            DropForeignKey("dbo.UserTags", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFeedbacks", "UserId", "dbo.Users");
            DropForeignKey("dbo.CreditCardUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.CreditCardUsers", "CreditCardInfoId", "dbo.CreditCardInfoes");
            DropForeignKey("dbo.ArtExamples", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Tags", "TagTypeId", "dbo.TagTypes");
            DropForeignKey("dbo.ArtExamples", "Tag_TagId", "dbo.Tags");
            DropForeignKey("dbo.ArtExampleTags", "ArtExampleId", "dbo.ArtExamples");
            DropIndex("dbo.ProjectStatusReportComments", new[] { "ProjectStatusReportId" });
            DropIndex("dbo.ProjectStatusReports", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "PictureId" });
            DropIndex("dbo.ArtMessages", new[] { "ArtExampleId" });
            DropIndex("dbo.ArtMessages", new[] { "UserMessageId" });
            DropIndex("dbo.UserFeedbacks", new[] { "UserId" });
            DropIndex("dbo.CreditCardUsers", new[] { "UserId" });
            DropIndex("dbo.CreditCardUsers", new[] { "CreditCardInfoId" });
            DropIndex("dbo.Users", new[] { "UserTypeId" });
            DropIndex("dbo.UserTags", new[] { "TagId" });
            DropIndex("dbo.UserTags", new[] { "UserId" });
            DropIndex("dbo.Tags", new[] { "TagTypeId" });
            DropIndex("dbo.ArtExampleTags", new[] { "ArtExampleId" });
            DropIndex("dbo.ArtExampleTags", new[] { "TagId" });
            DropIndex("dbo.ArtExamples", new[] { "Tag_TagId" });
            DropIndex("dbo.ArtExamples", new[] { "PictureId" });
            DropIndex("dbo.ArtExamples", new[] { "UserId" });
            DropTable("dbo.ProjectStatusReportComments");
            DropTable("dbo.ProjectStatusReports");
            DropTable("dbo.Projects");
            DropTable("dbo.Pictures");
            DropTable("dbo.UserMessages");
            DropTable("dbo.ArtMessages");
            DropTable("dbo.UserTypes");
            DropTable("dbo.UserFeedbacks");
            DropTable("dbo.CreditCardInfoes");
            DropTable("dbo.CreditCardUsers");
            DropTable("dbo.Users");
            DropTable("dbo.UserTags");
            DropTable("dbo.TagTypes");
            DropTable("dbo.Tags");
            DropTable("dbo.ArtExampleTags");
            DropTable("dbo.ArtExamples");
        }
    }
}

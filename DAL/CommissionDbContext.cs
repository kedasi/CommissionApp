using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Migrations;
using Domain;

namespace DAL
{
    public class CommissionDbContext : DbContext
    {
        public CommissionDbContext() : base("DbConnectionString")
        {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<CommissionDbContext, MigrationConfiguration>());
        }

        public DbSet<ArtExample> ArtExamples { get; set; }
        public DbSet<ArtExampleTag> ArtExampleTags { get; set; }
        public DbSet<ArtMessage> ArtMessages { get; set; }
        public DbSet<CreditCardInfo> CreditCardInfos { get; set; }
        public DbSet<CreditCardUser> CreditCardUsers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectStatusReport> ProjectStatusReports { get; set; }
        public DbSet<ProjectStatusReportComment> ProjectStatusReportComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagType> TagTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

    }
}
